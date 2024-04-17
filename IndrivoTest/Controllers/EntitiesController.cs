using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Bussines.Services;
using IndrivoTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndrivoTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }


        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return _entityService.GetEntities();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var entity = _entityService.GetEntityById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet("type/{id}")]
        public IActionResult GetByType(Guid id)
        {
            var entity = _entityService.GetEntityByType(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult AddEntity(Entity entity)
        {
            _entityService.AddEntity(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Guid }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntity(Guid id, Entity updatedEntity)
        {
            _entityService.UpdateEntity(id, updatedEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntity(Guid id)
        {
            _entityService.DeleteEntity(id);
            return NoContent();
        }
    }
}
