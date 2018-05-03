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
    /// Interaction logic for Filter2.xaml
    /// </summary>
    public partial class Filter2 : Page
    {
        OracleConnection connection;
        int flag = 0;
        OracleCommand command;
        int count = 0, noofpages = 0, curr = 0;
        public static ObservableCollection<Join> JoinCol { get; set; } = new ObservableCollection<Join>();
        //public static ObservableCollection<Join> JoinCol1 { get; set; } = new ObservableCollection<Join>();

        public ObservableCollection<Join> JoinCol2 { get; set; } = new ObservableCollection<Join>();
        public Filter2()
        {
            InitializeComponent();

            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            display2();
        }

        public void display2()
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT Employees.EMPNO, Employees.ENAME, Employees.SALARY,Employees.ROLE, Employees.DEPTID,Departments.DEPTNAME FROM Employees INNER JOIN Departments ON Employees.DEPTID = Departments.DEPTID";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            JoinCol.Clear();
            JoinCol.Clear();
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                //Emp e = new Emp
                //{
                //    EName = dataTableRow.ItemArray[1].ToString(),
                //    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                //    Esalary = float.Parse(dataTableRow.ItemArray[2].ToString())
                //};

                //collection.Add(e);

                JoinCol.Add(new Join()
                {
                    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                    EName = dataTableRow.ItemArray[1].ToString(),
                    Esalary = int.Parse(dataTableRow.ItemArray[2].ToString()),
                    Role = dataTableRow.ItemArray[3].ToString(),
                    DeptId = int.Parse(dataTableRow.ItemArray[4].ToString()),
                    DeptName = dataTableRow.ItemArray[5].ToString()

                });
            }

            JoinCol2 = new ObservableCollection<Join>(JoinCol);

            dg2.DataContext = null;

            dg2.DataContext = JoinCol;


            flag = 0;


        }

        private void btn_View2_Click(object sender, RoutedEventArgs e)
        {
            display2();
        }

        private void CusFilter_Click(object sender, RoutedEventArgs e)
        {
            var cs = new CustomFilter();
            cs.ShowDialog();
        }
    }
}
