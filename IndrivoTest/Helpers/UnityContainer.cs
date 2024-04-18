using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Bussines.Services;
using Unity;
using Unity.Lifetime;

namespace IndrivoTest.Helpers
{
    /// <summary>
    /// Provides methods for initializing and accessing the Unity container.
    /// </summary>
    public static class UnityConfig
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Initializes the Unity container with registered services using Singleton LifeCycle.
        /// </summary>
        public static void InitializeContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<ITypeService, TypeService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IEntityService, EntityService>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer GetContainer()
        {
            if (_container == null)
            {
                throw new InvalidOperationException("Unity container has not been initialized. Call Initialize Container method first.");
            }
            return _container;
        }
    }
}
