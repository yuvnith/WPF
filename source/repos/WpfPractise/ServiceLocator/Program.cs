using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLocator.Properties;

namespace ServiceLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            IService obj = ServiceLocator.LocateService(new ServiceB());
            obj.Service();
            Console.ReadKey();

        }
    }

    class ServiceA:IService
    {
        public void Service()
        {
            Console.WriteLine("A");
        }
    }

    class ServiceB : IService
    {
        public void Service()
        {
            Console.WriteLine("B");
        }
    }
}
