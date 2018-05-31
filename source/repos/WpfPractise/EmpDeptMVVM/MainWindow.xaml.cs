using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmpDeptMVVM.Views;

namespace EmpDeptMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICommand comm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            command();

            btn_commandButon.DataContext = comm;
        }

        private void command()
        {
            comm = new DemoCommand();
        }

        private void btn_Employee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataView emp = new EmployeeDataView();
            emp.ShowDialog();
        }
    }
}
