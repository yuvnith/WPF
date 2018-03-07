using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyList<T> : IMyList<T>
    {
        public List<T> myList = new List<T>();      
        public T GetElementAt(int x)
        {
            T res =  myList[x];
            Console.WriteLine("------------------");
            Console.WriteLine("element at " + x + " is " + res);
            return res;
        }

        public void Add(T x)
        {
            myList.Add(x);
            Console.WriteLine("added " + x);        
        }
        public void Print()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("List Values");
            foreach (var i in myList)
            Console.WriteLine(i);   
        }

        public bool Remove(T x)
        {
            Console.WriteLine("------------------");

            for(int i=0;i<myList.Count;i++)
            {
                if(myList[i].ToString() == x.ToString())
                {
                    Console.WriteLine("Removed " + myList[i].ToString());
                    myList.RemoveAt(i);
                    return true;
                }
            }

            Console.WriteLine(x+" item not found" );
            return false;
        }
    }
}
