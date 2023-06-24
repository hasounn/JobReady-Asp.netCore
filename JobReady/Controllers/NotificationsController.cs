using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly JobReadyContext context;
        public NotificationsController(JobReadyContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string view = "_Engagement")
        {
            var notification = new NotificationDetails()
            {
                Engagements = GetAllEngagements(),
                Recommendations = GetAllRecommendations(),
                Partial = view,
            };
            return View(notification);
        }

        #region Get Engagements
        public IActionResult GetEngagements()
        {
            return Index("_Engagement");
        }

        private IEnumerable<NotificationEngagementDetails> GetAllEngagements()
        {
            var currentUser = this.User.Claims.First().Value;
            var engagements = (from x in context.PostEngagement
                               where x.Post.CreatedById == currentUser && x.CreatedById != currentUser
                               orderby x.Id descending
                               select new NotificationEngagementDetails()
                               {
                                   CreatedBy = new UserAccountDetails()
                                   {
                                       Id = x.CreatedById,
                                       Username = x.CreatedBy.UserName,
                                       Headline = x.CreatedBy.Headline
                                   },
                                   EngagementType = x.EngagementType,
                                   CreatedOn = x.CreatedOn,
                                   Content = x.EngagementType == EngagementType.Like ? $"{x.CreatedBy.UserName} liked your post" : $"{x.CreatedBy.UserName} commented on your post",
                                   PostedOn = $"{x.CreatedOn.ToShortDateString()} - {x.CreatedOn.ToShortTimeString()}",
                               }).ToList();

            engagements.AddRange(from x in context.Follower
                                 where x.FollowingId == this.User.Claims.First().Value
                                 orderby x.Id descending
                                 select new NotificationEngagementDetails()
                                 {
                                     CreatedBy = new UserAccountDetails()
                                     {
                                         Id = x.UserAccountId,
                                         Username = x.UserAccount.UserName,
                                         Headline = x.UserAccount.Headline
                                     },
                                     EngagementType = EngagementType.Follow,
                                     CreatedOn = x.FollowedOn,
                                     Content = $"{x.UserAccount.UserName} followed you!",
                                     PostedOn = $"{x.FollowedOn.ToShortDateString()} - {x.FollowedOn.ToShortTimeString()}",
                                 });

            return engagements.OrderByDescending(x => x.CreatedOn).AsEnumerable().Take(20);
        }
        #endregion

        #region Get Recommendations
        public IActionResult GetRecommendations()
        {
            return Index("_RecommendationView");
        }

        private IEnumerable<RecommendationDetails> GetAllRecommendations()
        {
            var currentUser = this.User.Claims.First().Value;
            var currentType = (from x in context.UserAccount
                               where x.Id == currentUser
                               select x.AccountType).FirstOrDefault();
            ViewBag.cureentType = currentType;
            var isStudent = (currentType == UserAccountType.Student);


            var recommendations = (from x in context.Recommendation
                                   where (isStudent && x.StudentId == currentUser)
                                   || (!isStudent && x.InstructorId == currentUser && x.Status == RecommendationStatus.Pending)
                                   orderby x.Id descending, x.ResponseDate descending
                                   select new RecommendationDetails()
                                   {
                                       Id = x.Id,
                                       StudentId = x.StudentId,
                                       Student = new UserAccountDetails()
                                       {
                                           Id = x.Student.Id,
                                           Username = x.Student.UserName,
                                           Headline = x.Student.Headline,
                                       },
                                       InstructorId = x.InstructorId,
                                       Instructor = new UserAccountDetails()
                                       {
                                           Id = x.Instructor.Id,
                                           Username = x.Instructor.UserName,
                                           Headline = x.Instructor.Headline,
                                       },
                                       RequestDate = x.RequestDate,
                                       ResponseDate = x.ResponseDate,
                                       Status = x.Status,
                                       InstructorReply = x.InstructorReply,
                                       IsStudent = isStudent,
                                   }).AsQueryable();
            return recommendations;
        }
        #endregion  
    }
}
