using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
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

namespace WpfPractise.ADO.Data_Relation
{
    /// <summary>
    /// Interaction logic for DataRelation.xaml
    /// </summary>
    public partial class DataRelation : Window
    {
        public DataRelation()
        {
            InitializeComponent();
        }


        public void Emp()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            OracleDataAdapter adapter = new OracleDataAdapter("select * from Employees ",constring);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dg1.DataContext = dataset.Tables[0];
        }

        public void Dept()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            OracleDataAdapter adapter = new OracleDataAdapter("select * from Departments ", constring);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dg2.DataContext = dataset.Tables[0];
        }

        public void Combine()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            DataSet dataset = new DataSet();


            OracleDataAdapter adapter = new OracleDataAdapter("select * from Employees ", constring);
            adapter.Fill(dataset,"emp");

             OracleDataAdapter adapter2 = new OracleDataAdapter("select * from Departments ", constring);
            adapter2.Fill(dataset,"dept");

         
            System.Data.DataRelation dataRelation = new System.Data.DataRelation("combine", dataset.Tables[1].Columns[0], dataset.Tables[0].Columns[4]);
            dataset.Relations.Add(dataRelation);
            dataset.Relations[0].Nested = true;
            dg3.DataContext = dataset;
        }

        private void btn_employee_Click(object sender, RoutedEventArgs e)
        {
            Emp();
        }

        private void btn_department__Click(object sender, RoutedEventArgs e)
        {
            Dept();
        }

        private void btn_Combine_Click(object sender, RoutedEventArgs e)
        {
            Combine();
        }
    }
}
