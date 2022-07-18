using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using BlogAPI.Repository;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogContext _context;
        private readonly BlogRepository _blogRepository;
        public BlogsController(BlogContext blogContext)
        {
            _context = blogContext;
            _blogRepository = new BlogRepository(blogContext);
        }

        // GET: api/Blogs
        [HttpGet]
        public ActionResult<IEnumerable<BlogDto>> GetBlogs()
        {
            //return await _context.Blogs.Select(x => BlogToDto(x)).ToListAsync();
            var res = _blogRepository.GetAll();
            return res.ToList();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public ActionResult<BlogDto> GetBlog(long id)
        {
            var blog = _blogRepository.Get(id);

            if (blog == null)
            {
                return NotFound();
            }

            return BlogToDto(blog);
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBlog(long id, BlogDto blogDto)
        {
            if (id != blogDto.Id)
            {
                return BadRequest();
            }
            try
            {
                var blog = _blogRepository.Update(id, blogDto);
            }
            catch (DbUpdateConcurrencyException) when (!BlogExists(id))
            {
                return NotFound();
            }

            return NoContent();

        }

        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<BlogDto> PostBlog(BlogDto blogDto)
        {
            var blog = _blogRepository.Create(blogDto);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, BlogToDto(blog));
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(long id)
        {
            _blogRepository.Delete(id);
            return NoContent();
        }

        private bool BlogExists(long id)
        {
            return (_context.Blogs.Any(e => e.Id == id));
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
