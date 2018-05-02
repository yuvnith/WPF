using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPractise.ADO.Connected;

namespace WpfPractise.ADO.Pages
{
    /// <summary>
    /// Interaction logic for Departments.xaml
    /// </summary>
    public partial class Departments : Page
    {
        OracleConnection connection;
        OracleCommand command;
        public ObservableCollection<Temp1> DeptCol { get; set; } = new ObservableCollection<Temp1>();

        public Departments()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            InitializeComponent();


            display1();
        }

        public void display1()
        {
            command.Parameters.Clear();
            command.CommandText = "select * from Departments";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            DeptCol.Clear();
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                //Emp e = new Emp
                //{
                //    EName = dataTableRow.ItemArray[1].ToString(),
                //    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                //    Esalary = float.Parse(dataTableRow.ItemArray[2].ToString())
                //};

                //collection.Add(e);

                DeptCol.Add(new Temp1()
                {
                    DeptName = dataTableRow.ItemArray[1].ToString(),
                    Details = new ObservableCollection<Dept>
                    {
                        new Dept()
                        {
                            DeptName = dataTableRow.ItemArray[1].ToString(),
                            DeptId = int.Parse(dataTableRow.ItemArray[0].ToString())
                        }
                    }
                });
            }

            dg1.DataContext = null;
            dg1.DataContext = DeptCol;
        }
        private void btn_display1_Click(object sender, RoutedEventArgs e)
        {
            display1();
        }

        private void btn_add1_Click(object sender, RoutedEventArgs e)
        {
            string Deptname = inp_deptName1.Text;
            int Deptid = int.Parse(inp_deptid1.Text);
            command.Parameters.Clear();
            command.CommandText = "insert into departments(deptid,deptname) values(:deptid,:deptname)";
            command.Parameters.AddWithValue("deptid", Deptid);
            command.Parameters.AddWithValue("deptname", Deptname);

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            display1();
     

        }

        private void btn_delete1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_update1_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
