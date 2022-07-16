using PagedList.Core;
using QuickBlog.Data.Models;

namespace QuickBlog.Models.HomeViewModels
{
    public class AuthorViewModel
    {
        public ApplicationUser Author { get; set; }
        public IPagedList<Blog> Blogs { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
    }
}
