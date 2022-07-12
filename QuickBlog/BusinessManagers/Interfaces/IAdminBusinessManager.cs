using QuickBlog.Models.AdminViewModels;
using System.Security.Claims;

namespace QuickBlog.BusinessManagers.Interfaces
{
    public interface IAdminBusinessManager
    {
        Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal);
    }
}
 