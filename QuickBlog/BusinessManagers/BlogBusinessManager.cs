using Microsoft.AspNetCore.Identity;
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

        public BlogBusinessManager(UserManager<ApplicationUser> userManager,
                                    IBlogService blogService,
                                    IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
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
