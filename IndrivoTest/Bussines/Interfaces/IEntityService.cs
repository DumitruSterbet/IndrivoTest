
using IndrivoTest.Models;
namespace IndrivoTest.Bussines.Interfaces
{
    public interface IEntityService : IService<Entity>
    {
        List<Entity> GetEntityByType(Guid typeId);
    }
}
