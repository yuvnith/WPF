using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var obj = new Entities3())
            {
                var res = from e in obj.EMPLOYEES
                          select e;

                foreach (var re in res)
                {
                    Console.WriteLine(re.ENAME);
                }

                //DEPARTMENT res = new DEPARTMENT();
                //res = obj.DEPARTMENTS.Where(e => e.DEPTID == 6).Select(e => e).FirstOrDefault();
                //res.DEPTNAME = "saddd";
                //obj.SaveChanges();



            }



            Console.ReadKey();
        }
    }
}
