using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Models;
using Type = IndrivoTest.Models.Type;

namespace IndrivoTest.Bussines.Services
{
    public class EntityService : IEntityService
    {
        private List<Entity> entities;

        public EntityService()
        {
            entities = new List<Entity>() {
        new Entity()
        {
            Guid = Guid.Parse("36a73cd8-bfcf-41b7-9058-8e0f5b810fde"),
            Type =  new List<Type>() ,
            Title = "Apartament, cu 3 camere",
            DynamicFields = new Dictionary<string, object> { ["area"] = "value1",["sss"] ="value222" }, 
            Description = "mun.Chisinau, sec.Centru, bloc nou, etajul 3"
        },
        new Entity()
        {
            Guid = Guid.Parse("61add0de-48cd-4913-805a-e72538bd3419"),
            TypeId = new List<Guid>(){ Guid.Parse("a548ce15-8a2c-46a2-9953-df927feadffb"), Guid.Parse("ae97695a-9cba-465b-8126-9f24b80a48ac") } ,
            Type = new List<Type>()
            {
                   new Type() { Guid = Guid.Parse("a548ce15-8a2c-46a2-9953-df927feadffb"), Title = "imobil" },
                new Type() { Guid = Guid.Parse("ae97695a-9cba-465b-8126-9f24b80a48ac"), Title = "transport" }
            },
            Title = "Casa de locuit",
            DynamicFields = new Dictionary<string, object> { ["area"] = "value2" }, 
            Description = "mun.Chisinau, sat.Truseni, 2 nivele"
        },
        new Entity()
        {
            Guid = Guid.Parse("db8e41c8-85f8-400a-84e9-b65171dfbeb7"),
            Type = new List<Type>() ,
            Title = "Toyota RAV4",
            Description = "anul:2019, combustibil:motorina, locuri:5"
        }
    };
        }

        public List<Entity> GetEntities()
        {
            return entities;
        }
        public Entity GetEntityById(Guid id)
        {
            return entities.FirstOrDefault(e => e.Guid == id);
        }

        public void AddEntity(Entity entity)
        {
            entity.Guid = Guid.NewGuid(); // Assign a new GUID
            entities.Add(entity);
        }

        public void UpdateEntity(Guid id, Entity updatedEntity)
        {
            var entity = GetEntityById(id);
            if (entity != null)
            {
                // Update properties
                entity.Description = updatedEntity.Description;
                // You can update other properties here
            }
        }

        public void DeleteEntity(Guid id)
        {
            var entity = GetEntityById(id);
            if (entity != null)
            {
                entities.Remove(entity);
            }
        }

        public List<Entity> GetEntityByType(Guid typeId)
        {
            return entities.Where(entity => (bool)(entity.Type?.Any(type => type.Guid == typeId))).ToList();          
        }
    }
}
