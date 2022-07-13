using QuickBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlog.Service.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> GetBlog(int bligId);

        IEnumerable<Blog> GetBlog(ApplicationUser applicationUser);

        Task<Blog> Add(Blog blog);
    }
}
