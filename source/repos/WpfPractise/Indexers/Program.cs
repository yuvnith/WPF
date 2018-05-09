using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Inde();
            for (int i = 0; i < 5; i++)
            {
                obj[i] = i.ToString();
            }
            foreach (var o in obj.values)
            {
                Console.WriteLine(o);
            }

            Console.ReadKey();
        }
    }

    class Inde
    {
        public string[] values = new string[5];

        public string this[int index]
        {
            get
            {
                return values[index];
                
            }
            set { values[index] = value; }
        }



    }
}
