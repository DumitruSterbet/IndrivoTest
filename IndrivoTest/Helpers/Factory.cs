using IndrivoTest.Bussines.Services;
using Unity;

namespace IndrivoTest.Helpers
{
    public class Factory
    {
        private static readonly IUnityContainer _container = UnityConfig.GetContainer();
        public static TypeService typeCollection = _container.Resolve<TypeService>();
        public static  EntityService entityCollection = _container.Resolve<EntityService>();

    }
}
