using BlogAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; } = null;

        public static implicit operator BlogContext(BlogRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
