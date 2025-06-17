using APITODO.Model;
using DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace APITODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context) // inject DbContext
        {
            _context = context; // store it to use inside the methods
        }

        // Get all categories
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetCategories()
        {
            var cats = _context.Categories.Include(c => c.todos).ToList(); // get categories with todos

            if (cats.Count == 0)
                return Ok("Empty Result"); // if no categories found

            return Ok(cats); // return list of categories with 200 OK
        }

        // Get single category by ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetCategory(int id)
        {
            var cat = _context.Categories.Include(c => c.todos).FirstOrDefault(c => c.Id == id);
            if (cat == null)
                return NotFound(); // if not found

            return Ok(cat); // return the category
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateCategory(Category obj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // من التوكن

            var cat = new Category
            {
                Name = obj.Name,
                UserId = userId // ما نستخدم obj.UserId
            };

            _context.Categories.Add(cat);
            _context.SaveChanges();

            return Ok(cat);
        }


        // Update category by ID
        [HttpPost("{id}")]
        public ActionResult UpdateCategory(int id, Category updated)
        {
            var cat = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (cat == null)
                return NotFound();

            cat.Name = updated.Name; // update name
            _context.Categories.Update(cat);
            _context.SaveChanges();

            return Ok(cat); // return updated category
        }

        // Delete category by ID
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCategory(int id)
        {
            var cat = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (cat == null)
                return NotFound();

            _context.Categories.Remove(cat);
            _context.SaveChanges();

            return NoContent(); // return 204 No Content
        }
    }
}
