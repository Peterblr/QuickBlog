using Microsoft.AspNetCore.Mvc;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.Models.BlogViewModels;

namespace QuickBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogBusinessManager _blogBusinessManager;

        public BlogController(IBlogBusinessManager blogBusinessManager)
        {
            _blogBusinessManager = blogBusinessManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createBlogViewModel)
        {
            await _blogBusinessManager.CreateBlog(createBlogViewModel, User);

            return RedirectToAction("Create");
        }
    }
}
