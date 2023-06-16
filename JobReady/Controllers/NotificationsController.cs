using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            //var notifications = GetNotifications();
            //ViewData["Notifications"] = notifications;
            return View();
        }

        //    private List<Notification> GetNotifications()
        //    {
        //        var postEngagements = GetPostEngagements();
        //        var recommendations = GetRecommendations();
        //        var followers = GetFollowers();

        //        var notifications = new List<Notification>();

        //        foreach (var postEngagement in postEngagements)
        //        {
        //            notifications.Add(new Notification { Category = "all", Message = postEngagement.Message, Time = postEngagement.Time });
        //        }

        //        foreach (var recommendation in recommendations)
        //        {
        //            notifications.Add(new Notification { Category = "recommendations", Message = recommendation.Message, Time = recommendation.Time });
        //        }

        //        foreach (var follower in followers)
        //        {
        //            notifications.Add(new Notification { Category = "follow-requests", Message = follower.Message, Time = follower.Time });
        //        }

        //        return notifications;
        //    }

        //    private List<PostEngagement> GetPostEngagements()
        //    {
        //        // Replace this with your logic to retrieve post engagements from the database or any other data source
        //        var postEngagements = new List<PostEngagement>
        //        {
        //            new PostEngagement { Message = "User 1 liked your post.", Time = "1 hour ago" },
        //            new PostEngagement { Message = "User 2 commented on your post.", Time = "2 hours ago" }
        //        };

        //        return postEngagements;
        //    }

        //    private List<Recommendation> GetRecommendations()
        //    {
        //        // Replace this with your logic to retrieve recommendations from the database or any other data source
        //        var recommendations = new List<Recommendation>
        //        {
        //            new Recommendation { Message = "User 3 accepted your recommendation request.", Time = "3 hours ago" },
        //            new Recommendation { Message = "User 4 recommended you a new book.", Time = "4 hours ago" }
        //        };

        //        return recommendations;
        //    }

        //    private List<Follower> GetFollowers()
        //    {
        //        // Replace this with your logic to retrieve followers from the database or any other data source
        //        var followers = new List<Follower>
        //        {
        //            new Follower { Message = "User 5 has requested to follow you!", Time = "5 hours ago" },
        //            new Follower { Message = "User 6 started following you.", Time = "6 hours ago" }
        //        };

        //        return followers;
        //    }
    }
   
}
