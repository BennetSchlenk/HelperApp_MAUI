using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TODO_API.Data;
using TODO_API.Models;

namespace HelperAppAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/{id?}")]
    public class ToDoController : ControllerBase
    {
        private AppDbContext dbContext;

        public ToDoController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var userId = User.Claims.Where(t => t.Type == "uid").First().Value;
            var items = await dbContext.ToDos.Where(t=>t.UserId == userId).ToListAsync();

            return Ok(items);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ToDo toDo)
        {
            var userId = User.Claims.Where(t => t.Type == "uid").First().Value;
            var toDoModel = await dbContext.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            if (toDoModel == null)
            {
                return NotFound();
            }

            if (toDoModel.UserId != userId)
            {
                return Forbid();
            }

            toDoModel.ToDoName = toDo.ToDoName;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ToDo toDo)
        {
            var userId = User.Claims.Where(t => t.Type == "uid").First().Value;

            toDo.UserId = userId;
            await dbContext.ToDos.AddAsync(toDo);

            await dbContext.SaveChangesAsync();

            return Created($"api/todo/{toDo.Id}", toDo);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.Claims.Where(t => t.Type == "uid").First().Value;
            var toDoModel = await dbContext.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            if (toDoModel == null)
            {
                return NotFound();
            }

            if (toDoModel.UserId != userId)
            {
                return Forbid();
            }

            dbContext.ToDos.Remove(toDoModel);

            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
