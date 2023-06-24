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
            if (currentType == UserAccountType.Instructor)
            {
                var recommendations = (from x in context.Recommendation
                                       where x.InstructorId == currentUser && x.Status == RecommendationStatus.Pending
                                       orderby x.Id descending
                                       select new RecommendationDetails()
                                       {
                                           Id = x.Id,
                                           StudentId = x.StudentId,
                                           Student = new UserAccountDetails()
                                           {
                                               Username = x.Student.UserName,
                                           },
                                           InstructorId = x.InstructorId,
                                           RequestDate = x.RequestDate,
                                           Status = x.Status
                                       }).ToList();
                return recommendations.OrderByDescending(x => x.RequestDate).AsEnumerable().Take(20);
            }
            else
            {
                var recommendations = (from x in context.Recommendation
                                       where x.StudentId == currentUser
                                       orderby x.Id descending
                                       select new RecommendationDetails()
                                       {
                                           Id = x.Id,
                                           StudentId = x.StudentId,
                                           Student = new UserAccountDetails()
                                           {
                                               Username = x.Student.UserName,
                                           },
                                           InstructorId = x.InstructorId,
                                           RequestDate = x.RequestDate,
                                           Status = x.Status
                                       }).ToList();

                return recommendations.OrderByDescending(x => x.RequestDate).AsEnumerable().Take(20);
            }
        }
    }

}
