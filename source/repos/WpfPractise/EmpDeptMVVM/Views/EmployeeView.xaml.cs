using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EmpDeptMVVM.Models;
using EmpDeptMVVM.ViewModels;

namespace EmpDeptMVVM.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// View
    /// </summary>
    public partial class EmployeeDataView : Window
    {
        EmployeeDataViewModel edvm = new EmployeeDataViewModel();
        public EmployeeDataView()
        {
            InitializeComponent();
            edvm.GenerateData();
            dg.DataContext = edvm;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel emp = new EmployeeViewModel()
            {
                DEPTID = int.Parse(inp_deptid.Text),
                ENAME = inp_name.Text,
                ROLE = inp_role.Text,
                SALARY = int.Parse(inp_salary.Text),
                EMPNO = int.Parse(inp_no.Text)
            };
            edvm.AddData(emp);
            edvm.GenerateData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                EmployeeViewModel row = dg.SelectedItem as EmployeeViewModel;
                edvm.Delete(row);
                edvm.GenerateData();
            }
        }
    }
}
