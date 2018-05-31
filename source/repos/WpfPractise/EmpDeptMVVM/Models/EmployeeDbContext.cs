using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpDeptMVVM.ViewModels;

namespace EmpDeptMVVM.Models
{
    /// <summary>
    /// CRUD operations 
    /// </summary>
    class EmployeeDbContext
    {
        public void Add(EmployeeViewModel emp)
        {
            using (var obj = new Entities())
            {
                obj.EMPLOYEES.Add(emp.GetModel());
                obj.SaveChanges();
            }
        }

        public void Remove(EmployeeViewModel emp)
        {

        }

        public void Search(string id)
        {

        }

        public void Update(EmployeeViewModel emp)
        {

        }

        public List<EMPLOYEE> GetAllEmployees()
        {
            using (var obj = new Entities())
            {
                var data = from s in obj.EMPLOYEES
                    select s;
                return data.ToList();
            }
        }
    }
}
