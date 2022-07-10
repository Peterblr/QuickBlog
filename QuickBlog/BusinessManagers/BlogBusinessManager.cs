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

        public BlogBusinessManager(UserManager<ApplicationUser> userManager, IBlogService blogService)
        {
            _userManager = userManager;
            _blogService = blogService;
        }

        public async Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal)
        {
            Blog blog = createBlogViewModel.Blog;

            blog.Creator = await _userManager.GetUserAsync(claimsPrincipal);

            blog.CreatedOn = DateTime.Now;

            return await _blogService.Add(blog);

            
        }
    }
}
