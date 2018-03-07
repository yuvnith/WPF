using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
     interface IMyList<T>
    {
         T GetElementAt(int x);
         void Add(T x);
         bool Remove(T x);
         void Print(); 

    }
}
