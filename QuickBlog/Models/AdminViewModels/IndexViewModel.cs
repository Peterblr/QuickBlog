using QuickBlog.Data.Models;

namespace QuickBlog.Models.AdminViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
