using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var user = (from x in context.Users 
                        where x.UserName == this.User.Identity.Name 
                        select new UserAccountDetails()
                        {
                            Id = x.Id,
                            Username = x.UserName,
                            Headline = x.Headline,
                        }).FirstOrDefault();

            return View(new PostDetails() { CreatedBy = user});
        }



        [HttpGet]
        public IEnumerable<PostDetails> GetPosts()
        {
            var posts = (from x in context.Post
                        orderby x.CreatedOn descending
                        select new PostDetails()
                        {
                            Id = x.Id,
                            CreatedBy = new UserAccountDetails()
                            {
                                Id = x.CreatedById,
                                Headline = x.CreatedBy.Headline,
                                Username = x.CreatedBy.UserName,
                            },
                            Content = x.Content,
                            CreatedById = x.CreatedById,
                            CreatedOn = x.CreatedOn,
                        }).AsEnumerable();
            return posts;
        }

        public async Task<IActionResult> GetPostPicture(long postId)
        {
            var photoId = (from x in context.FileLink
                           where x.ObjectType == ObjectType.Post
                           && x.ObjectId == postId
                           select x.Id).FirstOrDefault();

            var photo = await context.FileLink.FindAsync(photoId);
            if (photo != null)
            {
                return File(photo.ContentHash, "image/*");
            }
            else
            {
                //return default image
                throw new Exception("Photo not found");
            }
        }
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

                    if (details.Image.Length > 0)
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
    }
}
