using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickBlog.Authorization;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.Data.Models;
using QuickBlog.Models.BlogViewModels;
using QuickBlog.Service.Interfaces;
using System.Security.Claims;

namespace QuickBlog.BusinessManagers
{
    public class BlogBusinessManager : IBlogBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAuthorizationService _authorizationService;

        public BlogBusinessManager(UserManager<ApplicationUser> userManager,
                                    IBlogService blogService,
                                    IWebHostEnvironment webHostEnvironment,
                                    IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
            _authorizationService = authorizationService;
        }

        public async Task<Blog> CreateBlog(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal)
        {
            Blog blog = createViewModel.Blog;

            blog.Creator = await _userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;
            blog.UpdatedOn = DateTime.Now;

            blog = await _blogService.Add(blog);

            string webRootPath = _webHostEnvironment.WebRootPath;
            string pathToImage = $@"{webRootPath}\UserFiles\Blogs\{blog.Id}\HeaderImage.jpg";
            EnsureFolder(pathToImage);

            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await createViewModel.BlogHeaderImage.CopyToAsync(fileStream);
            }

            return blog;            
        }

        public async Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal)
        {
            if (id is null)
                return new BadRequestResult();

            var blogId = id.Value;

            var blog = _blogService.GetBlog(blogId);

            if (blog is null)
                return new NotFoundResult();

            var authorizationResult = await _authorizationService.AuthorizeAsync(claimsPrincipal, blog, Operations.Update);

            if (!authorizationResult.Succeeded)
            {
                if (claimsPrincipal.Identity.IsAuthenticated)
                    return new ForbidResult();
                else
                    return new ChallengeResult();
            }
            //if (!authorizationResult.Succeeded) return DetermineActionResult(claimsPrincipal);

            return new EditViewModel
            {
                Blog = await blog
            };
        }

        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
