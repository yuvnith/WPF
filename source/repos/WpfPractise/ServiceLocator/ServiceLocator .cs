using ServiceLocator.Properties;

namespace ServiceLocator
{
    public static class ServiceLocator
    {
        public static IService ServiceObj = null;


        public static IService LocateService(IService service)
        {
            if (service != null)
            {
                ServiceObj = service;
            }

            return ServiceObj;

        }


    }
}