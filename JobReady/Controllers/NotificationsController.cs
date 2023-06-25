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
                Applications = GetAllApplications(),
                UserAccountType = GetUserType(),
                Partial = view,
            };
            var userType = (from x in context.UserAccount
                            where x.Id == this.User.Claims.First().Value
                            select x.AccountType).FirstOrDefault();
            ViewData["User"] = userType;
            return View(notification);
        }

        #region Get Type
        private UserAccountType GetUserType()
        {
            return (from x in context.Users where x.Id == this.User.Claims.First().Value
                    select x.AccountType).FirstOrDefault();
        }
        #endregion

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
            return RedirectToAction("Index","Notifications",new { view = "_RecommendationView" });
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
                                           FullName = x.Student.FullName,
                                           Headline = x.Student.Headline,
                                       },
                                       InstructorId = x.InstructorId,
                                       Instructor = new UserAccountDetails()
                                       {
                                           Id = x.Instructor.Id,
                                           Username = x.Instructor.UserName,
                                           FullName = x.Instructor.FullName,
                                           Headline = x.Instructor.Headline,
                                       },
                                       RequestDate = x.RequestDate,
                                       ResponseDate = x.ResponseDate,
                                       Status = x.Status,
                                       InstructorReply = x.InstructorReply,
                                       IsStudent = isStudent,
                                       Reply = new RecommendationReply()
                                       {
                                           Id = x.Id,
                                           Reply = x.InstructorReply
                                       }
                                   }).AsQueryable();
            return recommendations;
        }
        #endregion

        #region Get Applications
        public IActionResult GetApplications()
        {
            return RedirectToAction("Index", "Notifications", new { view = "_ApplicationView" });
        }

        private IEnumerable<JobApplicationDetails> GetAllApplications()
        {
            var currentUser = this.User.Claims.First().Value;
            var currentType = (from x in context.UserAccount
                               where x.Id == currentUser
                               select x.AccountType).FirstOrDefault();
            ViewBag.cureentType = currentType;
            var isCompany = (currentType == UserAccountType.Company);


            var jobApplications = (from x in context.JobApplication
                                   where (isCompany && x.JobPost.CreatedById == currentUser)
                                   || (!isCompany && x.ApplicantId == currentUser)
                                   orderby x.Id descending, x.AppliedOn descending
                                   select new JobApplicationDetails()
                                   {
                                       Id = x.Id,
                                       IsCompany = isCompany,
                                       JobPostId = x.JobPostId,
                                       JobPost = new JobPostDetails()
                                       {
                                           Id = x.Id,
                                           Title = x.JobPost.Title,
                                           IsRemote = x.JobPost.IsRemote,
                                           CreatedBy = new UserAccountDetails()
                                           {
                                               Id = x.JobPost.CreatedBy.Id,
                                               FullName = x.JobPost.CreatedBy.FullName,
                                               Username = x.JobPost.CreatedBy.UserName,
                                           }
                                       },
                                       ApplicantId = x.ApplicantId,
                                       Applicant = new UserAccountDetails()
                                       {
                                           Id = x.Applicant.Id,
                                           FullName = x.Applicant.FullName,
                                       },
                                       LetterOfMotivation = x.LetterOfMotivation,
                                       AppliedOn = x.AppliedOn,
                                      
                                   }).AsQueryable();
            return jobApplications;
        }
        #endregion
    }
}
