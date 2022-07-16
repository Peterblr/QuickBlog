using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.Models.BlogViewModels;

namespace QuickBlog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogBusinessManager _blogBusinessManager;

        public BlogController(IBlogBusinessManager blogBusinessManager)
        {
            _blogBusinessManager = blogBusinessManager;
        }

        [Route("Blog/{id}"), AllowAnonymous]
        public async Task<IActionResult> Index(int? id)
        {
            var actionResult = await _blogBusinessManager.GetBlogViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
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
