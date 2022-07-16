using Microsoft.AspNetCore.Mvc;
using QuickBlog.Models.HomeViewModels;

namespace QuickBlog.BusinessManagers.Interfaces
{
    public interface IHomeBusinessManager
    {
        ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page);
    }
}
