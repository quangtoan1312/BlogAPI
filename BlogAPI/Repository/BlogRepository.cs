using BlogAPI.Models;
using EF.Core.Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogAPI.Repository
{
    public class BlogRepository : IBlogRepository<Blog>
    {
        private readonly BlogContext _context;
        public BlogRepository(BlogContext context)
        {
            _context = context; 
        }

        public Blog Create(BlogDto blogDto)
        {
            var blog = new Blog
            {
                Title = blogDto.Title,
                Description = blogDto.Description,
                Detail = blogDto.Detail,
                Image = blogDto.Image,
                Position = blogDto.Position,
                Public = blogDto.Public,
                Category = blogDto.Category,
                PublicDate = blogDto.PublicDate,
            };

            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return blog;
        }

        public int Delete(long id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return 404;
            }
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return 204;
        }

        public Blog Get(long? id)
        {
            var blog =  _context.Blogs.Find(id);
            return blog;
        }

        public IEnumerable<BlogDto> GetAll()
        {
            return _context.Blogs.Select(x => BlogToDto(x)).ToList();
        }

        public int Update(long id, BlogDto blogDto)
        {
            var blog = _context.Blogs.Find(id);
            if(blog == null)
            {
                return 404;
            }
            blog.Title = blogDto.Title;
            blog.Description = blogDto.Description;
            blog.Detail = blogDto.Detail;
            blog.Image = blogDto.Image;
            blog.Position = blogDto.Position;
            blog.Public = blogDto.Public;
            blog.Category = blogDto.Category;
            blog.PublicDate = blogDto.PublicDate;
            _context.SaveChanges();
            return 204;
        }

        private static BlogDto BlogToDto(Blog blog) =>
            new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Detail = blog.Detail,
                Image = blog.Image,
                Position = blog.Position,
                Public = blog.Public,
                Category = blog.Category,
                PublicDate = blog.PublicDate
            };
    }
}
