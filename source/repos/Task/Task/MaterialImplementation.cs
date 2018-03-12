using System;
using System.Collections.Generic;

namespace Task
{
    public class MaterialImplementation :IMaterial
    {
        public List<Materials> MyList = new List<Materials>();

        public void Add(Materials mat )
        {
            MyList.Add(mat);
        }

        public void Display()
        {
            foreach (var mat in MyList)
            {
                Console.WriteLine("Id : " + mat.MaterialId);
                Console.WriteLine("class : "+mat.Class);
                Console.WriteLine("Description : " + mat.Description);
                Console.WriteLine("Grp : " + mat.Grp);
                Console.WriteLine("Mat Type : " + mat.MaterialType);
                Console.WriteLine("Smc : " + mat.Smc);
                Console.WriteLine("Type : " + mat.Type);
                Console.WriteLine("Units : " + mat.Units);
                Console.WriteLine("-----------------------------");
            }
        }

        public Materials Find(string id)
        {
            foreach (var item in MyList)
            {
                if (item.MaterialId == id)
                    return item;
            }
            return null;
        }
    }
}