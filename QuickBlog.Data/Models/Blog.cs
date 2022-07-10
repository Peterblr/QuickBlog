using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlog.Data.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser Creator { get; set; } = new ApplicationUser { FirstName = "temp", LastName = "temp"};

        [Required]
        public string Title { get; set; } = "temp";
        [Required]
        public string Content { get; set; } = "temp";
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Published { get; set; }

        public bool Approved { get; set; }
        public ApplicationUser Approver { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
