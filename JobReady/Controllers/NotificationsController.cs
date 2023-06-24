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
    }

}
