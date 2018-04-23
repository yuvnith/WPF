using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace WpfPractise.ADO.Connected
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        OracleConnection connection;
        OracleCommand command;

        //  public ObservableCollection<Emp> collection { get; set; } = new ObservableCollection<Emp>();
        public ObservableCollection<Temp> collection2 { get; set; } = new ObservableCollection<Temp>();

        public ObservableCollection<Temp1> DeptCol { get; set; } = new ObservableCollection<Temp1>();

        public ObservableCollection<Join> JoinCol { get; set; } = new ObservableCollection<Join>();

        public ObservableCollection<Temp2> JoinTree { get; set; } = new ObservableCollection<Temp2>();
        public enum Roles
        {
            Manager = 3,
            Lead = 2,
            Developer = 1,
            Tester = 1
        }

        public Employee()
        {
            InitializeComponent();


            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            display();

            display1();

            display2();


        }

        public void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string name = inp_name.Text;
            float salary = float.Parse(inp_salary.Text);
            int no = int.Parse(inp_no.Text);
            int deptid = int.Parse(inp_deptid.Text);
            string role = inp_role.Text;
            command.Parameters.Clear();
            command.CommandText = "insert into Employees (EMPNO,ENAME,SALARY,ROLE,DEPTID) values(:EMPNO,:ENAME,:SALARY,:ROLE,:DEPTID)";
            command.Parameters.AddWithValue("EMPNO", no);
            command.Parameters.AddWithValue("ENAME", name);
            command.Parameters.AddWithValue("SALARY", salary);
            command.Parameters.AddWithValue("ROLE", role);
            command.Parameters.AddWithValue("DEPTID", deptid);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            display();

            display1();

            display2();
        }

        public void display()
        {
            command.Parameters.Clear();
            command.CommandText = "select * from Employees";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            //collection.Clear();
            collection2.Clear();
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                //Emp e = new Emp
                //{
                //    EName = dataTableRow.ItemArray[1].ToString(),
                //    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                //    Esalary = float.Parse(dataTableRow.ItemArray[2].ToString())
                //};

                //collection.Add(e);

                collection2.Add(new Temp
                {
                    EName = dataTableRow.ItemArray[1].ToString(),
                    Details = new ObservableCollection<Emp>
                    {
                        new Emp
                        {
                            EName = dataTableRow.ItemArray[1].ToString(),
                            Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                            Esalary = float.Parse(dataTableRow.ItemArray[2].ToString()),
                            Role = dataTableRow.ItemArray[3].ToString(),
                            DeptId = int.Parse(dataTableRow.ItemArray[4].ToString())
                        }
                    }
                });
            }

            dg.DataContext = null;
            dg.DataContext = collection2;
            Tree.DataContext = null;
            Tree.DataContext = collection2;


        }

        private void btn_display_Click(object sender, RoutedEventArgs e)
        {
            display();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            command.Parameters.Clear();
            command.CommandText = "select * from Employees where EMPNO = :empno";
            command.Parameters.AddWithValue("empno", int.Parse(inp_no.Text));
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            //dg.DataContext = dataTable;

            inp_name.Text = dataTable.Rows[0].ItemArray[1].ToString();

            inp_salary.Text = dataTable.Rows[0].ItemArray[2].ToString();
            inp_role.Text = dataTable.Rows[0].ItemArray[3].ToString();
            inp_deptid.Text = dataTable.Rows[0].ItemArray[4].ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            command.Parameters.Clear();
            command.CommandText = "delete from Employees where EMPNO = :empno";
            command.Parameters.AddWithValue("empno", int.Parse(inp_no.Text));
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            display();
            display1();
            display2();
            inp_no.Text = "";
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            string name = inp_name.Text;
            float salary = float.Parse(inp_salary.Text);
            int no = int.Parse(inp_no.Text);
            int deptid = int.Parse(inp_deptid.Text);
            string role = inp_role.Text;
            command.Parameters.Clear();
            command.CommandText = "update Employees set ENAME=:ename,SALARY=:salary,ROLE=:role,DEPTID=:deptid where EMPNO =:empno ";
            command.Parameters.AddWithValue("EMPNO", no);
            command.Parameters.AddWithValue("ENAME", name);
            command.Parameters.AddWithValue("SALARY", salary);
            command.Parameters.AddWithValue("ROLE", role);
            command.Parameters.AddWithValue("DEPTID", deptid);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            display();
            display1();
            display2();
            inp_no.Text = "";
            inp_name.Text = "";
            inp_salary.Text = "";
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
            display2();

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

            dg2.DataContext = null;
            dg2.DataContext = JoinCol;


            var dev = new ObservableCollection<Temp2>();
            var test = new ObservableCollection<Temp2>();
          

            foreach (var col in JoinCol)
            {
                if (col.Role.ToUpper() == "DEVELOPER")
                    dev.Add(new Temp2()
                    {
                        EName = col.EName
                    });
                else if (col.Role.ToUpper() == "TESTER")
                    test.Add(new Temp2()
                    {
                        EName = col.EName
                    });
            }

            foreach (var col in JoinCol)
            {
                if (col.Role.ToUpper() == "MANAGER")
                {
                    JoinTree.Add(new Temp2()
                    {
                        EName = col.EName,
                        Developers = dev,
                        Testers = test
                    });
                    break;
                }
              
            }
            TreeView2.DataContext = JoinTree;
        }
        private void btn_display1_Click(object sender, RoutedEventArgs e)
        {
            display1();
        }

        private void dg2_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dg2SelectedItems = dg2.SelectedItems.GetEnumerator();
            dg2SelectedItems.MoveNext();
            var joinobject = (Join)dg2SelectedItems.Current;
            int deptid = int.Parse(joinobject?.DeptId.ToString());


            command.Parameters.Clear();
            command.CommandText = "select * from Employees where deptid=:id";
            command.Parameters.AddWithValue("id", deptid);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            dg4.DataContext = dataTable;

            //((Join)new List<Join>()(dg2.SelectedItems).Items[0]).DeptId
        }
    }

    public class Emp
    {
        public string EName { get; set; }
        public int? Eno { get; set; }
        public float? Esalary { get; set; }
        public string Role { get; set; }
        public int DeptId { get; set; }



    }

    public class Temp
    {
        public string EName { get; set; }
        public ObservableCollection<Emp> Details { get; set; }
    }

    public class Dept
    {
        public string DeptName { get; set; }
        public int? DeptId { get; set; }

    }

    public class Temp1
    {
        public string DeptName { get; set; }
        public ObservableCollection<Dept> Details { get; set; }
    }

    public class Join
    {
        public string EName { get; set; }
        public int? Eno { get; set; }
        public float? Esalary { get; set; }
        public string Role { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }

    public class Manager
    {
        public string EName { get; set; }
        public ObservableCollection<Join> Leads { get; set; }
    }

    public class Lead
    {
        public string EName { get; set; }
        public ObservableCollection<Join> Developers { get; set; }

        public ObservableCollection<Join> Testers { get; set; }
    }

    public class Temp2
    {
        public string EName { get; set; }
        public int? Eno { get; set; }
        public float? Esalary { get; set; }
        public string Role { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public ObservableCollection<Temp2> Leads { get; set; }
        public ObservableCollection<Temp2> Developers { get; set; }
        public ObservableCollection<Temp2> Testers { get; set; }

    }



}
