using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MaterialCollection : List<Material>
    {
        
        
        public Material GetMaterialWithMaxPrice()
        {
            int max = 0;
            Material mat = null;
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (max < enumerator.Current.Price)
                {
                    max = enumerator.Current.Price;
                    mat = enumerator.Current;
                }
            }
            return mat;
        }

       

        public Material FindMatertialWithId(string id)
        {
            Material mat = null;
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Id == id)
                {
                    mat = enumerator.Current;
                }
            }
            return mat;
       
        }

    }

    public class Material
    {
        public Material(String id, int price, int stock)
        {
            this.Id = id;
            this.Price = price;
            this.Stock = stock;
        }


        public string Id { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }
    }


}
