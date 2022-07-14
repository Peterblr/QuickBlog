using PagedList.Core;
using QuickBlog.Data.Models;

namespace QuickBlog.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public IPagedList<Blog> Blogs { get; set; }

        public string SearchString { get; set; }

        public int PageNumber { get; set; }
    }
}
