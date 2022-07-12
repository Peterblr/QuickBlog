using QuickBlog.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace QuickBlog.Models.BlogViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name = "Header Image")]
        public IFormFile BlogHeaderImage { get; set; }

        public Blog Blog { get; set; }
    }
}
