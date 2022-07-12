using Microsoft.EntityFrameworkCore;
using QuickBlog.Data;
using QuickBlog.Data.Models;
using QuickBlog.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlog.Service
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BlogService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Blog> Add(Blog blog)
        {           
            _applicationDbContext.Add(blog);
            await _applicationDbContext.SaveChangesAsync();

            return blog;
        }

        public IEnumerable<Blog> GetBlog(ApplicationUser applicationUser)
        {
            return _applicationDbContext.Blogs
                .Include(blog => blog.Creator)
                .Include(blog => blog.Approver)
                .Include(blog => blog.Posts)
                .Where(blog => blog.Creator == applicationUser);
        }
    }
}
