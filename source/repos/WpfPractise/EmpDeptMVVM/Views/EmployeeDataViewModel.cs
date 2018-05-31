using System.Collections.ObjectModel;
using System.Linq;
using EmpDeptMVVM.Models;
using EmpDeptMVVM.ViewModels;

namespace EmpDeptMVVM.Views
{
    /// <summary>
    /// Screen view model
    /// </summary>
    class EmployeeDataViewModel
    {
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }= new ObservableCollection<EmployeeViewModel>();
        EmployeeDbContext DbContext = new EmployeeDbContext();
        public EmployeeViewModel CurrentEmployee = new EmployeeViewModel();
        public void GenerateData()
        {
            var employees = DbContext.GetAllEmployees();
            Employees.Clear();
            foreach (var emp in employees)
            {
                Employees.Add(new EmployeeViewModel(emp));
            }
        }

        public void AddData(EmployeeViewModel employee)
        {
            DbContext.Add(employee);
           
        }

        public void Delete(EmployeeViewModel employee)
        {
            using (var obj = new Entities())
            {
                EMPLOYEE d = (from s in obj.EMPLOYEES
                    where s.EMPNO ==  employee.EMPNO
                    select s).FirstOrDefault();
                obj.EMPLOYEES.Remove(d);
                obj.SaveChanges();
            }
        }
    }
}
