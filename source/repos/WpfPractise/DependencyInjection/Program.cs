using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Client client = new Client(new B());
            //client.Work();

            Client2 client2 = new Client2();
            client2.Service = new B();
            client2.Work();

            Console.ReadKey();
        }
    }


    class A : IService
    {
        public void Display()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("A");
            }
        }
    }
    class B : IService
    {
        public void Display()
        {
            for (int i = 0; i < 17; i++)
            {
                Console.WriteLine("B");
            }
        }
    }
    class C : IService
    {
        public void Display()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("C");
            }
        }
    }

    /// <summary>
    /// Constructor Dependency Injection
    /// </summary>
    public class Client
    {
        private IService _service;
        public Client(IService service)
        {
            this._service = service;
        }

        public void Work()
        {
            _service.Display();
        }
    }


    /// <summary>
    /// Property Dependency Injection
    /// </summary>
    public class Client2
    {
        private IService _service;

        public IService Service
        {
            get => _service;
            set => _service = value;
        }


        public void Work()
        {
            _service.Display();
        }


    }
}
