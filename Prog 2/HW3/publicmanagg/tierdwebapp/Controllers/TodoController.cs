using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tierdwebapp.Models;
using tierdwebapp.Repositories;

namespace tierdwebapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/todo/{id}
        [HttpGet("{id:guid}", Name = "GetTodo")]
        public async Task<ActionResult<TodoItem>> Get(Guid id)
        {
            var item = await _repository.GetAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/todo
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create([FromBody] TodoItem create)
        {
            var created = await _repository.CreateAsync(create);
            return CreatedAtRoute("GetTodo", new { id = created.Id }, created);
        }

        // PUT: api/todo/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TodoItem update)
        {
            if (id != update.Id) return BadRequest("Id mismatch.");
            var ok = await _repository.UpdateAsync(update);
            if (!ok) return NotFound();
            return NoContent();
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _repository.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}