using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Task
{
    public interface IMaterial
    {
        void Add(Materials mat);
        void Display();

        Materials Find(string id);
    }
}