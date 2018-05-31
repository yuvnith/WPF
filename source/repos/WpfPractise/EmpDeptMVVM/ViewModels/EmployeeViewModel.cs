using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpDeptMVVM.Models;

namespace EmpDeptMVVM.ViewModels
{
    /// <summary>
    /// Entity view model
    /// </summary>
public class EmployeeViewModel
    {
        public EmployeeViewModel(EMPLOYEE emp)
        {
            _employee = emp;
        }

        public EmployeeViewModel()
        {
            _employee = new EMPLOYEE();
        }

        private EMPLOYEE _employee;
        public decimal EMPNO
        {
            get { return _employee.EMPNO; }
            set { _employee.EMPNO = value; }
        }

        public string ENAME
        {
            get { return _employee.ENAME; }
            set { _employee.ENAME = value; }
        }

        public Nullable<decimal> SALARY
        {
            get { return _employee.SALARY; }
            set { _employee.SALARY = value; }
        }
        public string ROLE
        {
            get { return _employee.ROLE; }
            set { _employee.ROLE = value; }
        }
        public Nullable<decimal> DEPTID
        {
            get { return _employee.DEPTID; }
            set { _employee.DEPTID = value; }
        }

        public EMPLOYEE GetModel()
        {
            return _employee;
        }
    }
}
