using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            RefA aobj = new RefA();
            Type a = aobj.GetType();
            MethodInfo[] aMethodInfo = a.GetMethods();

            //Console.WriteLine(a.Name);

            //foreach (var methodInfo in aMethodInfo)
            //{
            //    if (methodInfo.Name == "MethodB")
            //    {
            //        object[] param = {1,2};
            //        methodInfo.Invoke(aobj,param);

            //        ParameterInfo[] parameters = methodInfo.GetParameters();
            //        foreach (var parameter in parameters)
            //        {
            //            Console.WriteLine(parameter.Name);
            //        }

            //    }

            //}

            FieldInfo[] finfo = a.GetFields();
            foreach (var f in finfo)
            {
                Console.WriteLine(f);
            }
            Console.ReadKey();
        }
    }

    class RefA
    {
        public void MethodA()
        {
            Console.WriteLine("class RfefA & MethodA");
        }

        public void MethodB(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public int a;
    
    }

}
