using Microsoft.AspNetCore.Mvc;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.Models;
using System.Diagnostics;

namespace QuickBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogBusinessManager _blogBusinessManager;

        public HomeController(IBlogBusinessManager blogBusinessManager)
        {
            _blogBusinessManager = blogBusinessManager;
        }

        public IActionResult Index(string searchString, int? page)
        {
            return View(_blogBusinessManager.GetIndexViewModel(searchString, page));
        }
    }
}