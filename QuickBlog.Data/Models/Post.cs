using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlog.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }        

        [Required]
        public string Title { get; set; } = "temp";
        [Required]
        public string Content { get; set; } = "temp";
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Blog Blog { get; set; }
        public ApplicationUser Poser { get; set; }
    }
}
