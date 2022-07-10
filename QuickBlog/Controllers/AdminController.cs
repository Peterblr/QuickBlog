using Microsoft.AspNetCore.Mvc;

namespace QuickBlog.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
