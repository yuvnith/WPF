using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MaterialCollection : List<Material>
    {
        public List<Material> matList = new List<Material>();
        public Material GetMaterialWithMaxPrice()
        {
            int max = 0,j=0;           
            for(int i=0;i<matList.Count;i++)
            {
                if (matList[i].Price > max)
                {
                    max = matList[i].Price;
                    j = i;
                }
            }
            return matList[j];
        }

        public Material FindMatertialWithId(string id)
        {
            for (int i = 0; i < matList.Count; i++)
            {
                if (matList[i].Id == id)
                {
                    return matList[i];
                }
            }

            return null;
      
        }

    }
    public class Material
    {
        public Material(String id,int price,int stock)
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
