using Microsoft.AspNetCore.Identity;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.Data.Models;
using QuickBlog.Models.AdminViewModels;
using QuickBlog.Service.Interfaces;
using System.Security.Claims;

namespace QuickBlog.BusinessManagers
{
    public class AdminBusinessManager : IAdminBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBlogService _blogService;

        public AdminBusinessManager(UserManager<ApplicationUser> userManager,
                                    IBlogService blogService)
        {
            _userManager = userManager;
            _blogService = blogService;
        }

        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel
            {
                Blogs = _blogService.GetBlog(applicationUser)
            };
        }
    }
}
