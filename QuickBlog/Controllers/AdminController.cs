using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickBlog.BusinessManagers.Interfaces;

namespace QuickBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminBusinessManager _adminBusinessManager;

        public AdminController(IAdminBusinessManager adminBusinessManager)
        {
            _adminBusinessManager = adminBusinessManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _adminBusinessManager.GetAdminDashboard(User));
        }
    }
}
