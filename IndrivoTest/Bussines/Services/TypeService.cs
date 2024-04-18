using IndrivoTest.Bussines.Interfaces;
using Type = IndrivoTest.Models.Type;

namespace IndrivoTest.Bussines.Services
{
    public class TypeService : ITypeService
    {
        private List<Type> types;

        public TypeService()
        {
            types = new List<Type>() {
                new Type() { Guid = Guid.Parse("a548ce15-8a2c-46a2-9953-df927feadffb"), Title = "imobil" },
                new Type() { Guid = Guid.Parse("ae97695a-9cba-465b-8126-9f24b80a48ac"), Title = "transport" },
                new Type() { Guid = Guid.Parse("0050a70f-bb06-470f-8721-616c08d7ef14"), Title = "nou" },
                new Type() { Guid = Guid.Parse("71b54e78-ade1-4ce2-992f-e37cdc290373"), Title = "de mina a doua" }
            };
        }

        public List<Type> GetEntities()
        {
            return types;
        }

        public Type GetEntityById(Guid id)
        {
            return types.FirstOrDefault(t => t.Guid == id);
        }

        public void AddEntity(Type type)
        {
            type.Guid = Guid.NewGuid();
            types.Add(type);
        }

        public void UpdateEntity(Guid id, Type updatedType)
        {
            var index = types.FindIndex(t => t.Guid == id);
            if (index != -1)
            {
                types[index] = updatedType;
            }
             
        }

        public void DeleteEntity(Guid id)
        {
            var type = types.FirstOrDefault(t => t.Guid == id);
            if (type != null)
            {
                types.Remove(type);
            }
        }
    }
}
