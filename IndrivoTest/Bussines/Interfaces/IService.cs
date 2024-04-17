namespace IndrivoTest.Bussines.Interfaces
{
    public interface IService<T>
    {
        List<T> GetEntities();
        T GetEntityById(Guid id);
        void AddEntity(T entity);
        void UpdateEntity(Guid id, T updatedEntity);
        void DeleteEntity(Guid id);
    }
}
