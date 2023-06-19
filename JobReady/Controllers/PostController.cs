﻿using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace JobReady.Controllers
{
    public class PostController : Controller
    {
        private readonly JobReadyContext context;
        public PostController(JobReadyContext context)
        {
            this.context = context;
        }
        #region Index
        public IActionResult Index()
        {
            var user = (from x in context.Users 
                        where x.UserName == this.User.Identity.Name 
                        select new UserAccountDetails()
                        {
                            Id = x.Id,
                            FullName = x.FullName,
                            Username = x.UserName,
                            Headline = x.Headline,
                        }).FirstOrDefault();

            return View(new PostDetails() { CreatedBy = user});
        }
        #endregion

        #region Get Post Picture
        public async Task<IActionResult> GetPostPicture(long imageId)
        {
            var photo = await context.FileLink.FindAsync(imageId);
            if (photo != null)
            {
                return File(photo.ContentHash, "image/*");
            }
            else
            {
                //return default image
                return File("/assets/images/image-placeholder.png", "image/png");
            }
        }
        #endregion

        #region Get Post
        [HttpGet]
        public PostDetails GetPost(long postId)
        {
            var post = (from x in context.Post
                         join y in context.FileLink on x.Id equals y.ObjectId into images
                         from i in images.DefaultIfEmpty()
                         where x.Id == postId && (i == null || i.ObjectType == ObjectType.Post)
                         orderby x.CreatedOn descending
                         select new PostDetails()
                         {
                             Id = x.Id,
                             CreatedBy = new UserAccountDetails()
                             {
                                 Id = x.CreatedById,
                                 FullName = x.CreatedBy.FullName,
                                 Headline = x.CreatedBy.Headline,
                                 Username = x.CreatedBy.UserName,
                             },
                             Content = x.Content,
                             ImageId = i.Id,
                             CreatedById = x.CreatedById,
                             CreatedOn = x.CreatedOn,
                         }).FirstOrDefault();
            post.HasLiked = HasLiked(post.Id, this.User.Claims.First().Value);
            post.LikesCount = GetTotalEngagementCount(postId, EngagementType.Like);
            post.Comments = GetPostComments(postId);
            return post;
        }
        #endregion

        #region Create Post
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDetails details)
        {
            if (ModelState.IsValid)
            {
                using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                try
                {
                    var newPost = new Post()
                    {
                        Content = details.Content,
                        CreatedById = this.User.Claims.First().Value,
                        CreatedOn = DateTime.Now,
                    };

                    context.Post.Add(newPost);
                    await context.SaveChangesAsync();

                    if (details.Image != null && details.Image.Length > 0)
                    {
                        using var memoryStream = new MemoryStream();
                        await details.Image.CopyToAsync(memoryStream);
                        if (memoryStream.Length < 2097152)
                        {
                            var newPhoto = new FileLink()
                            {
                                ContentHash = memoryStream.ToArray(),
                                Name = details.Image.FileName,
                                ContentSize = details.Image.Length,
                                ObjectType = ObjectType.Post,
                                ObjectId = newPost.Id,
                                CreatedById = this.User.Claims.First().Value,
                                CreatedOn = DateTime.Now,
                            };
                            context.FileLink.Add(newPhoto);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            ModelState.AddModelError("Photo", "The Photo is too large");
                            return RedirectToAction("Index", "Home");
                        }
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Total Engagement Count
        public long GetTotalEngagementCount(long postId, EngagementType type )
        {
            var likesCount = (from x in context.PostEngagement
                              where x.PostId == postId && x.EngagementType == type
                              select x).Count();
            return likesCount;
        }
        #endregion

        #region Has Liked
        public bool HasLiked(long postId, string userId)
        {
            return (from x in context.PostEngagement
                    where x.PostId == postId && x.CreatedById == userId
                    select x).Any();
        }
        #endregion

        #region Like/Unlike Post
        [HttpPost]
        public IActionResult LikePost([FromBody]long postId)
        {
            var like = (from x in context.PostEngagement
                        where x.PostId == postId
                        && x.EngagementType == EngagementType.Like
                        && x.CreatedById == this.User.Claims.First().Value
                        select x).FirstOrDefault();
            if (like == null)
            {

                like = new PostEngagement()
                {
                    PostId = postId,
                    EngagementType = EngagementType.Like,
                    CreatedById = this.User.Claims.First().Value,
                    CreatedOn = DateTime.Now,
                };
                context.PostEngagement.Add(like);
                context.SaveChanges();
            }

            var likesCount = GetTotalEngagementCount(postId, EngagementType.Like);
            return Ok(likesCount);

        }

        [HttpPost]
        public IActionResult UnlikePost([FromBody]long postId)
        {
            var like = (from x in context.PostEngagement
                        where x.PostId == postId
                          && x.EngagementType == EngagementType.Like
                        && x.CreatedById == this.User.Claims.First().Value
                        select x).FirstOrDefault();
            if (like != null)
                context.PostEngagement.Remove(like);
                context.SaveChanges();
            var likesCount = GetTotalEngagementCount(postId, EngagementType.Like);

            return Ok(likesCount);
        }
        #endregion

        #region Comment on Post
        [HttpPost]
        public IActionResult Comment([FromBody] long postId, [FromBody] string content)
        {
            var comment = new PostEngagement()
            {
                PostId = postId,
                Content = content,
                CreatedById = this.User.Claims.First().Value,
                CreatedOn = DateTime.Now,
                EngagementType = EngagementType.Comment,
            };
            context.PostEngagement.Add(comment);
            context.SaveChanges();
            return Ok(new { this.User.Identity.Name, comment.CreatedOn });
        }
        #endregion

        #region Get Post Comments
        public IEnumerable<PostEngagementDetails> GetPostComments(long postId)
        {
            var comments = (from x in context.PostEngagement
                            where x.Id == postId && x.EngagementType == EngagementType.Comment
                            select new PostEngagementDetails()
                            {
                                Id = x.Id,
                                Content = x.Content,
                                CreatedOn = x.CreatedOn,
                                CreatedById = x.CreatedById,
                                CreatedBy = new UserAccountDetails()
                                {
                                    Id = x.CreatedBy.Id,
                                    FullName = x.CreatedBy.FullName,
                                    Username = x.CreatedBy.UserName,
                                }
                            }).AsEnumerable();
            return comments;
        }
        #endregion
    }
}
