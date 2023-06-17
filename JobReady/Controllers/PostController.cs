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

        [HttpGet]
        public IEnumerable<PostDetails> GetPost(long postId)
        {
            var posts = (from x in context.Post
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
                                 Headline = x.CreatedBy.Headline,
                                 Username = x.CreatedBy.UserName,
                             },
                             Content = x.Content,
                             ImageId = i.Id,
                             CreatedById = x.CreatedById,
                             CreatedOn = x.CreatedOn,
                         }).AsEnumerable();
            return posts;
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
