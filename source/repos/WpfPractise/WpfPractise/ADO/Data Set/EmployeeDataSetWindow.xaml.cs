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
using System.Windows.Shapes;

namespace WpfPractise.ADO.Data_Set
{
    /// <summary>
    /// Interaction logic for EmployeeDataSetWindow.xaml
    /// </summary>
    public partial class EmployeeDataSetWindow : Window
    {
        public EmployeeDataSetWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           // Mocks.WpfPractise_ADO_Data_Set_EmployeeDataSet_86_367953720 employeeDataSet = ((Mocks.WpfPractise_ADO_Data_Set_EmployeeDataSet_86_367953720)(this.FindResource("employeeDataSet")));
            // TODO: Add code here to load data into the table EMPLOYEES.
            // This code could not be generated, because the employeeDataSetEMPLOYEESTableAdapter.Fill method is missing, or has unrecognized parameters.
            WpfPractise.ADO.Data_Set.EmployeeDataSetTableAdapters.EMPLOYEESTableAdapter employeeDataSetEMPLOYEESTableAdapter = new WpfPractise.ADO.Data_Set.EmployeeDataSetTableAdapters.EMPLOYEESTableAdapter();
            System.Windows.Data.CollectionViewSource eMPLOYEESViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("eMPLOYEESViewSource")));
            eMPLOYEESViewSource.View.MoveCurrentToFirst();
        }
    }
}
