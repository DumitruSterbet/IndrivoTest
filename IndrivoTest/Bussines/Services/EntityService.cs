using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Helpers;
using IndrivoTest.Models;
using System.Data;
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
            Title = "Toyota RAV4",
            Description = "anul:2019, combustibil:motorina, locuri:5",
            TypeId = new List<Guid>(){ Guid.Parse("a548ce15-8a2c-46a2-9953-df927feadffb")} ,
            Type = new List<Type>()
            {
                   new Type() { Guid = Guid.Parse("a548ce15-8a2c-46a2-9953-df927feadffb"), Title = "imobil" },             
            },
        }
    };
        }

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        /// <exception cref="EntityNotFoundException">Thrown when the entity list is empty.</exception>

        public List<Entity> GetEntities()
        {
            if (entities.Any())
            {
                return entities;
            }
            else
            {
                throw new EntityNotFoundException($"Entity list is empty");
            }
        }

        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID.</returns>
        public Entity GetEntityById(Guid id)
        {
            Entity result = entities.FirstOrDefault(e => e.Guid == id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new EntityNotFoundException($"Entity with Id {id} not found");
            }

        }
        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(Entity entity)
        {
            entity.Guid = Guid.NewGuid(); // Assign a new GUID
            entities.Add(entity);
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="updatedEntity">The updated entity data.</param>
        public void UpdateEntity(Guid id, Entity updatedEntity)
        {
            Entity entity = GetEntityById(id);
            if (entity != null)
            {
                entity.Description = updatedEntity.Description;
                entity.Title = updatedEntity.Title;
                entity.TypeId = updatedEntity.TypeId;
                entity.Type = updatedEntity.Type;
                entity.DynamicFields = updatedEntity.DynamicFields;
            }
        }


        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        public void DeleteEntity(Guid id)
        {
            Entity entity = GetEntityById(id);
            if (entity != null)
            {
                entities.Remove(entity);
            }

        }

        /// <summary>
        /// Retrieves entities by type.
        /// </summary>
        /// <param name="typeId">The ID of the type.</param>
        /// <returns>A list of entities with the specified type.</returns>
        public List<Entity> GetEntityByType(Guid typeId)
        {
            List<Entity> groupedEntities = entities
                           .Where(entity => entity.TypeId !=null && entity.TypeId.Contains(typeId))
                           .ToList();
            if (groupedEntities.Any())
            {
                return groupedEntities;
            }
            else
            {
                throw new EntityNotFoundException($"Entities for Type with Id {typeId} not found");
            }

        }
    }
}
