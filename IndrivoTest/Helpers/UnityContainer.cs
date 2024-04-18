using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Bussines.Services;
using IndrivoTest.Models;
using Unity;

namespace IndrivoTest.Helpers
{
 
    public static class UnityConfig
    {
        private static IUnityContainer _container;

        public static void InitializeContainer()
        {
            _container = new UnityContainer();        
            _container.RegisterType<ITypeService, TypeService>(); 
                                                                   
        }

        public static IUnityContainer GetContainer()
        {
            if (_container == null)
            {
                throw new InvalidOperationException("Unity container has not been initialized. Call InitializeContainer method first.");
            }
            return _container;
        }
    }
}
