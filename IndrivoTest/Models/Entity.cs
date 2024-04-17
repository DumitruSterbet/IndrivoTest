
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IndrivoTest.Models
{
    public class Entity
    {
        


        public Guid Guid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Guid> TypeId { get; set; }

        [JsonIgnore]
        public List<Type> Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> DynamicFields { get; set; }

        public Entity()
        {
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
