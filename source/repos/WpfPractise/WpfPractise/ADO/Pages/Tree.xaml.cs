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
    /// Interaction logic for Tree.xaml
    /// </summary>
    public partial class Tree : Page
    {
        OracleConnection connection;
        OracleCommand command;

        public ObservableCollection<Temp> collection2 { get; set; } = new ObservableCollection<Temp>();
        public ObservableCollection<JoinTree> JoinTree2 { get; set; } = new ObservableCollection<JoinTree>();

        public Tree()
        {
            InitializeComponent();
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            generate();
            Tree3();
        }
        public void generate()
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


            Tree2.DataContext = null;
            Tree2.DataContext = collection2;
        }

        public void Tree3()
        {
            JoinTree2.Clear();
            command.Parameters.Clear();
            //command.CommandText = "SELECT distinct(deptid) from employees";
            command.CommandText = "SELECT deptid from departments";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                JoinTree2.Add(new JoinTree()
                {
                    DeptId = int.Parse(dataTableRow.ItemArray[0].ToString()),
                    EName = dataTableRow.ItemArray[0].ToString(),
                    Emp = new ObservableCollection<JoinTree>()
                });
            }

            foreach (var j in JoinTree2)
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT * from employees where deptid=:did";
                command.Parameters.AddWithValue("did", j.DeptId);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                dataTable = new DataTable();
                dataTable.Load(dataReader);

                foreach (DataRow dataTableRow in dataTable.Rows)
                {
                    if (dataTableRow.ItemArray[3].ToString().ToLower().Trim() == "manager")
                    {
                        j.Emp.Add(new JoinTree()
                        {
                            EName = dataTableRow.ItemArray[1].ToString(),
                            Role = dataTableRow.ItemArray[3].ToString(),
                            Emp = new ObservableCollection<JoinTree>()
                        });
                    }
                }
            }

            foreach (var j in JoinTree2)
            {
                foreach (var j2 in j.Emp)
                {
                    command.Parameters.Clear();
                    command.CommandText = "SELECT distinct(role),ename from employees where deptid=:did";
                    command.Parameters.AddWithValue("did", j.DeptId);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    dataTable = new DataTable();
                    dataTable.Load(dataReader);


                    foreach (DataRow dataTableRow in dataTable.Rows)
                    {
                        if (dataTableRow.ItemArray[0].ToString().ToLower().Trim().Contains("lead"))
                        {
                            j2.Emp.Add(new JoinTree()
                            {
                                EName = dataTableRow.ItemArray[1].ToString(),
                                Role = dataTableRow.ItemArray[0].ToString(),
                                Emp = new ObservableCollection<JoinTree>()
                            });
                        }
                    }
                }
            }

            foreach (var j in JoinTree2)
            {
                foreach (var j2 in j.Emp)
                {
                    foreach (var j3 in j2.Emp)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "SELECT * from employees where deptid=:did";
                        command.Parameters.AddWithValue("did", j.DeptId);
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        dataTable = new DataTable();
                        dataTable.Load(dataReader);


                        if (j3.Role.ToLower().Trim() == "dlead")
                        {
                            foreach (DataRow dataTableRow in dataTable.Rows)
                            {
                                if (dataTableRow.ItemArray[3].ToString().ToLower().Trim() == "developer")
                                {
                                    j3.Emp.Add(new JoinTree()
                                    {
                                        EName = dataTableRow.ItemArray[1].ToString(),
                                        Role = dataTableRow.ItemArray[3].ToString(),
                                    });
                                }
                            }
                        }

                        if (j3.Role.ToLower().Trim() == "tlead")
                        {
                            foreach (DataRow dataTableRow in dataTable.Rows)
                            {
                                if (dataTableRow.ItemArray[3].ToString().ToLower().Trim() == "tester")
                                {
                                    j3.Emp.Add(new JoinTree()
                                    {
                                        EName = dataTableRow.ItemArray[1].ToString(),
                                        Role = dataTableRow.ItemArray[3].ToString(),
                                    });
                                }
                            }
                        }

                    }

                }
            }


            TreeView.DataContext = JoinTree2;

        }
    }
}
