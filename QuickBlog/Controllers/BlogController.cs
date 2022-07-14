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

        public async Task<IActionResult> Edit(int? id)
        {
            var actionResult = await _blogBusinessManager.GetEditViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createBlogViewModel)
        {
            await _blogBusinessManager.CreateBlog(createBlogViewModel, User);

            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditViewModel editBlogViewModel)
        {
            var actionResult = await _blogBusinessManager.UpdateBlog(editBlogViewModel, User);

            if (actionResult.Result is null)
            {
                return RedirectToAction("Edit", new { editBlogViewModel.Blog.Id });
            }

            return actionResult.Result;
        }
    }
}
