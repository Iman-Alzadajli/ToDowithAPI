using APITODO.Model;
using DAL.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace APITODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context; // store the context to use it in the methods
        }

       

        // Get a specific todo by ID
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var todos = await _context.Todos
                .Include(t => t.Category)
                .Where(t => t.UserId == userId)
                .ToListAsync();

            if (todos.Count == 0)
                return Ok("No tasks found for this user.");

            return Ok(todos);
        }

        // Create a new todo
        [HttpPost]
        [Authorize] // تأكدي أنك مفعلة التوثيق
        public async Task<ActionResult> CreateTodo(Todo obj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // take user from token 

            Todo todo = new Todo()
            {
                Name = obj.Name,
                Description = obj.Description,
                IsCompeleted = obj.IsCompeleted,
                piriority = obj.piriority,
                CategoryId = obj.CategoryId,
                CreatedAt = DateTime.Now,
                UserId = userId // this will help to connect todolist to user 
            };

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        // Update a todo by ID
        [HttpPost("{id}")]
        public ActionResult UpdateTodo(int id, Todo updated)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            // update fields
            todo.Name = updated.Name;
            todo.Description = updated.Description;
            todo.IsCompeleted = updated.IsCompeleted;
            todo.piriority = updated.piriority;
            todo.CategoryId = updated.CategoryId;

            _context.Todos.Update(todo);
            _context.SaveChanges();

            return Ok(todo); // return updated todo
        }

        // Delete a todo by ID
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteTodo(int id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return NoContent(); // deleted successfully
        }
    }
}