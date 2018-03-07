using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class TypeSafeArrayList<T> : ArrayList
    {
        String type;
        int count ;
        public ArrayList myArrayList = new ArrayList();
        public void add(T val)
        {
            if (myArrayList.Count == 0)
            {
                type = val.GetType().ToString();
                myArrayList.Add(val);
                Console.WriteLine("added value : " + val);
            }
            else
            {
                if (type == val.GetType().ToString())
                {
                    myArrayList.Add(val);
                    Console.WriteLine("added value : " + val);
                }
                else
                {
                    Console.WriteLine("cannot add value : " + val);
                }
            }
        }

        public void print()
        {
            Console.WriteLine("values are ");
            foreach (var i in myArrayList)
                Console.WriteLine(i);
        }

    }
}
