using IndrivoTest.Bussines.Services;
using Unity;

namespace IndrivoTest.Helpers
{
    public class Factory
    {
        private static readonly IUnityContainer _container = UnityConfig.GetContainer();

        public static TypeService TypeService()
        {
            return _container.Resolve<TypeService>();
        }
    }
}
