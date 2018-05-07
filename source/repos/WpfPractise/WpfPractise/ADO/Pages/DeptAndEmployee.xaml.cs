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
    /// Interaction logic for DeptAndEmployee.xaml
    /// </summary>
    public partial class DeptAndEmployee : Page
    {
        OracleConnection connection;
        OracleCommand command;

        public ObservableCollection<Temp1> DeptCol { get; set; } = new ObservableCollection<Temp1>();

        public DeptAndEmployee()
        {
            InitializeComponent();
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;


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




        private void dg1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dg1SelectedItems = dg1.SelectedItems.GetEnumerator();
            dg1SelectedItems.MoveNext();
            var joinobject = (Temp1)dg1SelectedItems.Current;
            int deptid = int.Parse(joinobject?.Details[0].DeptId.ToString());


            command.Parameters.Clear();
            command.CommandText = "select * from Employees where deptid=:id";
            command.Parameters.AddWithValue("id", deptid);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            dg4.DataContext = dataTable;

        }
    }
}
