using CustomerAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors]
    [ApiController]
    public class GenericController<T> : ControllerBase where T:class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllValues();
            return Ok(items);
        }

        [HttpGet("{Key}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(long Key)
        {
            var item = await _repository.GetEntityById(Key);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T entity)
        {
            await _repository.AddEntity(entity);
            return CreatedAtAction(nameof(GetById), new { Key = entity.GetType().GetProperty("AccountNo")?.GetValue(entity) }, entity);
        }

        [HttpPut("{Key}")]
        public async Task<IActionResult> Update(long Key, [FromBody] T entity)
        {
            var entityId = entity.GetType().GetProperty("AccountNo")?.GetValue(entity);
            if (entityId == null || (long)entityId != Key)
            {
                return BadRequest("ID mismatch");
            }

            await _repository.UpdateEntity(entity);
            return NoContent();
        }

        [HttpDelete("{Key}")]
        public async Task<IActionResult> Delete(long Key)
        {
            await _repository.DeleteEntity(Key);
            return NoContent();
        }

    }
}
