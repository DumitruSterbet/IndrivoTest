using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Helpers;
using IndrivoTest.Models;
using Microsoft.AspNetCore.Mvc;
using static Unity.Storage.RegistrationSet;

namespace IndrivoTest.Controllers
{
    /// <summary>
    /// Controller for managing entities.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public EntityController()
        {
            _entityService = Factory.entityCollection;
        }

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_entityService.GetEntities());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The retrieved entity if found, else NotFound.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Entity entity = _entityService.GetEntityById(id);
                
                return Ok(entity);
            }          
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    return NotFound();
                }
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves entities by type ID.
        /// </summary>
        /// <param name="id">The ID of the type.</param>
        /// <returns>Entities of the specified type if found, else NotFound.</returns>
        [HttpGet("type/{id}")]
        public IActionResult GetByType(Guid id)
        {
            try
            {
                List<Entity> entity = _entityService.GetEntityByType(id);
                
                return Ok(entity);
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    return NotFound();
                }
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>CreatedAtAction result.</returns>
        [HttpPost]
        public IActionResult AddEntity(Entity entity)
        {
            try
            {   entity.ValidateInputedTypeId();
                _entityService.AddEntity(entity);
                return CreatedAtAction(nameof(GetById), new { id = entity.Guid }, entity);
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    return NotFound();
                }
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="updatedEntity">The updated entity data.</param>
        /// <returns>NoContent result.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateEntity(Guid id, Entity updatedEntity)
        {
            try
            {
                updatedEntity.ValidateInputedTypeId();
                _entityService.UpdateEntity(id, updatedEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    return NotFound();
                }
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>NoContent result.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEntity(Guid id)
        {
            try
            {
                _entityService.DeleteEntity(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    return NotFound();
                }
                return BadRequest(ex.Message);
            }
        }
    }
}
