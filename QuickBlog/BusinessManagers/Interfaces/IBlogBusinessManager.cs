using QuickBlog.Data.Models;
using QuickBlog.Models.BlogViewModels;
using System.Security.Claims;

namespace QuickBlog.BusinessManagers.Interfaces
{
    public interface IBlogBusinessManager
    {
        Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
