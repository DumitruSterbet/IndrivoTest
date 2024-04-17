using IndrivoTest.Bussines.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Type = IndrivoTest.Models.Type;

namespace IndrivoTest.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public IEnumerable<Type> Get()
        {
            return _typeService.GetEntities();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var type = _typeService.GetEntityById(id);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }

        [HttpPost]
        public IActionResult Post(Type type)
        {
            _typeService.AddEntity(type);
            return CreatedAtAction(nameof(Get), new { id = type.Guid }, type);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Type updatedType)
        {
            _typeService.UpdateEntity(id, updatedType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _typeService.DeleteEntity(id);
            return NoContent();
        }
    }  

    
}
