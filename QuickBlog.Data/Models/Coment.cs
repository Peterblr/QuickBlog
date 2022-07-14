using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlog.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }        

        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

        public Blog Blog { get; set; }
        public ApplicationUser Author { get; set; }

        public Comment Parent { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
