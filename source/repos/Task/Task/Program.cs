using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program  
    {
        static void Main(string[] args)
        {
            IMyList<int> MyListObject = new MyList<int>();
            MyListObject.Add(10);
            MyListObject.Add(20);
            MyListObject.Add(30);
            MyListObject.Remove(0);
            int a = MyListObject.GetElementAt(0);
            MyListObject.Print();

            Console.WriteLine(" ");
            IMyList<String> MyListObject2 = new MyList<String>();
            MyListObject2.Add("a");
            MyListObject2.Add("b");
            MyListObject2.Add("c");
            MyListObject2.Remove("a");
            String b = MyListObject2.GetElementAt(0);
            MyListObject2.Print();

            Console.WriteLine("----------------------------------------------------------------------");

            MaterialCollection MaterialCollectionObject = new MaterialCollection();
            //id price stock
            Material mat1 = new Material("0", 100, 200);
            MaterialCollectionObject.matList.Add(mat1);
            Material mat2 = new Material("1", 120, 300);
            MaterialCollectionObject.matList.Add(mat2);
            Material mat3 = new Material("2", 140, 400);
            MaterialCollectionObject.matList.Add(mat3);

            Material m1 = MaterialCollectionObject.GetMaterialWithMaxPrice();
            Console.WriteLine("maximum price is " + m1.Price);
            Material m2 = MaterialCollectionObject.FindMatertialWithId("0"); ;
            Console.WriteLine("material details are:");
            Console.WriteLine("id : " + m2.Id + " Stock : " + m2.Stock + " Price : " + m2.Price);


            Console.WriteLine("----------------------------------------------------------------------");


            TypeSafeArrayList TypeSafeArrayListObject = new TypeSafeArrayList();
            TypeSafeArrayListObject.add(1);
            TypeSafeArrayListObject.add("adsd");
            TypeSafeArrayListObject.add(2);
            TypeSafeArrayListObject.add("sad");


            TypeSafeArrayListObject.print();






            Console.ReadKey();

        }
    }
    
}
