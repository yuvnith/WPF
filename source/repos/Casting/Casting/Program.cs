using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            //SmartPhone smart = new SmartPhone();
            //smart.id = 123;
            //Phone obj = smart as Phone;
            //Console.WriteLine(obj.id);


            //BasicPhone phone = new BasicPhone();
            //phone.id = 1452;
            //Phone P =  phone;
            //Console.WriteLine(P.id);




            //Android android = new Android(){version2 = 123, id = 1, camera = 12, cost = 12000, releasedate = "may", version = 12 };
            //Phone phone = android;

            //int a ;
            //string c = "sadasdasdsaa";



            //if (!int.TryParse(c, out a))
            //{
            //    Console.WriteLine("unable to parse ");
            //}



            //covariance
            //List<String> stringlist = new List<string>(){"one","two","three"};
            //cannot cast derived type to derived type 
            //List<object> objectlist = (List<object>)stringlist;

            //casting here is possible because enumerables are read only
            //IEnumerable<object>  objenum  =stringlist;


            //Demo();


           


            try
            {
                Vehichle vehichle = new Vehichle();
                double m = vehichle.MileageCalculator(-1, -2, -3);
            }
            catch (NegativeValueException e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

        public static void Demo()
        {
            Demo();
            Console.WriteLine("in demo method ");
        }

        static void Recursive(int value)
        {
            try
            {
                Console.WriteLine(value);
                Recursive(++value);
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e);
            }
            
        }
    }

    public class Phone
    {
        public int id { get; set; }
        public string releasedate { get; set; }
        public int cost { get; set; }
    }

    public class SmartPhone : Phone, ISmartPhone
    {
        public int version { get; set; }
        public int camera { get; set; }
    }

    public class BasicPhone : Phone, IBasicPhone
    {
        public int simslots { get; set; }
        public bool camera { get; set; }
    }

    public class Android : SmartPhone
    {
        public int version2 { get; set; }
    }

    public class IOS : SmartPhone
    {
        public int version { get; set; }
    }
}
