using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program  
    {
        static void Main(string[] args)
        {
            //IMyList<int> MyListObject = new MyList2<int>();
            //MyListObject.Add(10);
            //MyListObject.Add(20);
            //MyListObject.Add(30);
            //MyListObject.Add(40);
            //MyListObject.Add(50);
            //MyListObject.Print();
            //Console.WriteLine(" ");
            //MyListObject.Remove(30);
            //MyListObject.Print();

            //Console.WriteLine(" ");
            //int a = MyListObject.GetElementAt(2);
            //Console.WriteLine(a);


            //Console.WriteLine(" ");


            //Console.WriteLine("----------------------------------------------------------------------");

            MaterialCollection MaterialCollectionObject = new MaterialCollection();
            //id price stock
            //Material mat1 = new Material("0", 100, 200);
            //Material mat2 = new Material("1", 120, 300);
            //Material mat3 = new Material("2", 140, 400);
            //Material mat4 = new Material("2", 180, 400);

            //MaterialCollectionObject.Add(mat1);
            //MaterialCollectionObject.Add(mat2);
            //MaterialCollectionObject.Add(mat3);
            //MaterialCollectionObject.Add(mat4);

            //Material m1 = MaterialCollectionObject.GetMaterialWithMaxPrice();



            //Console.WriteLine("maximum price is " + m1.Price);
            //Material m2 = MaterialCollectionObject.FindMatertialWithId("0"); ;
            //Console.WriteLine("material details are:");
            //Console.WriteLine("id : " + m2.Id + " Stock : " + m2.Stock + " Price : " + m2.Price);
            //Console.WriteLine("----------------------------------------------------------------------");


            //TypeSafeArrayList<int> TypeSafeArrayListObject = new TypeSafeArrayList<int>();
            //TypeSafeArrayListObject.add(1);
            ////TypeSafeArrayListObject.add("adsd");
            //TypeSafeArrayListObject.add(2);
            ////TypeSafeArrayListObject.add("sad");
            //TypeSafeArrayListObject.print();




            //Site[] sites = new Site[3];
            //for(int i = 1; i < 4; i++)
            //{
            //    Site site1 = new Site();
            //    site1.Id = i.ToString();

            //    sites[i - 1] = site1;
            //}

            //var data = new List<MaterialSiteRelation>();
            //var randomNumberGenerator = new Random();
            //Mat[] materialsarr = new Mat[999];
            //for (int i = 1; i < 1000; i++)
            //{
            //    var site = sites[i % 3];
            //    Mat mat1 = new Mat() { Id = randomNumberGenerator.Next(1, 100).ToString(), Site = site, Price = randomNumberGenerator.Next(10, 1000) };
            //    materialsarr[i - 1] = mat1;
            //    var matSiteRelation = new MaterialSiteRelation() { site = site, material = mat1, Quantity = randomNumberGenerator.Next(1, 100) };
            //    data.Add(matSiteRelation);
            //}
            //var totalQuantiy = new SiteHelper().GetTotalQuantityOfMaterial("4", data);
            //var totalBudget = new SiteHelper().GetTotalBudgetAtSite("2", data);
            //Console.WriteLine(totalBudget + "");
            //Console.WriteLine(totalQuantiy);
            //Console.ReadKey();

            

            //CusomizedCollection obj1 = new CusomizedCollection();
            //obj1.Add(String.Empty);

        }
    }


    public class SiteHelper
    {
        public int GetTotalQuantityOfMaterial(string matid, List<MaterialSiteRelation> data)
        {
            int total = 0;
            foreach (var dataitem in data)
            {
                if(dataitem.material.Id == matid)
                {
                    total += dataitem.Quantity;
                }
            }
            return total;
        }

        public int GetTotalBudgetAtSite(string siteId, List<MaterialSiteRelation> data)
        {           
            int budget = 0;
            foreach (var dataitem in data)
            {
                if (dataitem.site.Id == siteId)
                {
                    budget += (dataitem.material.Price * dataitem.Quantity);
                }
            }
            return budget;

        }
    }
    
}
