using IndrivoTest.Helpers;
using System.Text.Json.Serialization;

namespace IndrivoTest.Models
{
    /// <summary>
    /// Represents an entity with a unique identifier, type, title, description, and dynamic fields.
    /// </summary>
    public class Entity
    {
        public Guid Guid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Guid> TypeId
        { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<Type> Type { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> DynamicFields { get; set; }

        /// <summary>
        /// Validates the Type property by checking if any of the TypeIds match existing Types Id form Type Object.
        /// </summary>
        /// <remarks>
        /// If no matching GUIDs from existing types are found, it throws an InvalidOperationException.
        /// </remarks>
        /// 

        public Entity()
        {
            Type = new List<Type>();
        }
        public void ValidateInputedTypeId()
        {
            if (TypeId != null && !GetIntersectedTypes().Count().Equals(TypeId.Count))
            {
                throw new InvalidOperationException("You didn't enter a GUID from an existing type.");
            }
        }

        private IEnumerable<Guid> GetIntersectedTypes()
        {
            return Factory.typeCollection.GetEntities().Select(u => u.Guid).Intersect(TypeId);
        }
    }
}
