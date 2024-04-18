using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Helpers;
using Microsoft.AspNetCore.Mvc;
using Type = IndrivoTest.Models.Type;

namespace IndrivoTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController()
        {
            _typeService = Factory.typeCollection;
        }

        /// <summary>
        /// Retrieves all Type entities.
        /// </summary>
        /// <returns>A collection of all Type entities.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_typeService.GetEntities());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a Type entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Type entity to retrieve.</param>
        /// <returns>The retrieved Type entity if found, else NotFound.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Type type = _typeService.GetEntityById(id);
                if (type == null)
                {
                    return NotFound();
                }
                return Ok(type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new Type entity.
        /// </summary>
        /// <param name="type">The Type entity to create.</param>
        /// <returns>The newly created Type entity.</returns>
        [HttpPost]
        public IActionResult Post(Type type)
        {
            try
            {
                _typeService.AddEntity(type);
                return CreatedAtAction(nameof(Get), new { id = type.Guid }, type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing Type entity.
        /// </summary>
        /// <param name="id">The ID of the Type entity to update.</param>
        /// <param name="updatedType">The updated Type entity.</param>
        /// <returns>NoContent if successful, else BadRequest.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Type updatedType)
        {
            try
            {
                _typeService.UpdateEntity(id, updatedType);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a Type entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Type entity to delete.</param>
        /// <returns>NoContent if successful, else BadRequest.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _typeService.DeleteEntity(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
