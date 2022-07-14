using Microsoft.AspNetCore.Mvc;
using QuickBlog.Data.Models;
using QuickBlog.Models.BlogViewModels;
using QuickBlog.Models.HomeViewModels;
using System.Security.Claims;

namespace QuickBlog.BusinessManagers.Interfaces
{
    public interface IBlogBusinessManager
    {
        Task<Blog> CreateBlog(CreateViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> UpdateBlog(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal);

        IndexViewModel GetIndexViewModel(string searchString, int? page);
    }
}
