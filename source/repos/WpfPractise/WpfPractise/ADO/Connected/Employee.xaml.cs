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

        public ObservableCollection<Manager> JoinTree { get; set; } = new ObservableCollection<Manager>();


        public ObservableCollection<JoinTree> JoinTree2 { get; set; } = new ObservableCollection<JoinTree>();
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

            Tree3();

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

            Tree3();
        }




        public void tree()
        {
            JoinTree.Clear();
            var leads = new ObservableCollection<Lead>();
            var temp2 = new ObservableCollection<Join>();


            for (int i = 0; i < JoinCol.Count; i++)
            {
                var t1 = new ObservableCollection<Join>();
                var t2 = new ObservableCollection<Join>();
                foreach (var jo in JoinCol)
                {
                    if (jo.Role.ToUpper() == "DEVELOPER")
                        t1.Add(jo);
                    if (jo.Role.ToUpper() == "TESTER")
                        t2.Add(jo);
                }
                if (JoinCol[i].Role.ToLower().Trim() == "lead" && JoinCol[i].EName.ToLower().Trim() == "lead1")
                {
                    leads.Add(new Lead()
                    {
                        EName = JoinCol[i].EName,
                        E = t1
                    });
                }

                if (JoinCol[i].Role.ToLower().Trim() == "lead" && JoinCol[i].EName.ToLower().Trim() == "lead2")
                {
                    leads.Add(new Lead()
                    {
                        EName = JoinCol[i].EName,
                        E = t2
                    });
                }
            }

            foreach (Join t in JoinCol)
            {
                if (t.Role.ToUpper() == "MANAGER")
                {
                    JoinTree.Add(new Manager()
                    {
                        EName = t.EName,
                        Leads = leads
                    });
                }
            }
            TreeView2.DataContext = JoinTree;
        }

        public void Tree2()
        {
            JoinTree2.Clear();
            foreach (var j in JoinCol)
            {
                if (j.Role.ToLower().Trim() == "manager")
                {
                    if (JoinTree2.Count == 0)
                    {
                        JoinTree2.Add(new JoinTree()
                        {
                            EName = j.EName,
                            Emp = new ObservableCollection<JoinTree>()
                        });
                    }
                    else
                    {
                        JoinTree2[0].EName = j.EName;
                    }
                }

                else if (j.Role.ToLower().Trim() == "tlead")
                {
                    if (JoinTree2.Count == 1)
                    {
                        int flag = 0;
                        foreach (var jj in JoinTree2[0].Emp)
                        {
                            if (jj.Role.ToLower().Trim() == "tlead")
                            {
                                jj.EName = j.EName;
                                flag = 1;
                            }
                        }

                        if (flag == 0)
                        {
                            JoinTree2[0].Emp.Add(new JoinTree()
                            {
                                EName =  j.EName,
                                Role = j.Role,
                                Emp = new ObservableCollection<JoinTree>()
                            });
                        }
                    }
                    else
                    {
                        JoinTree2.Add(new JoinTree()
                        {
                            EName = "",
                            Emp = new ObservableCollection<JoinTree>()
                        });
                        JoinTree2[0].Emp.Add(new JoinTree()
                        {
                            EName = j.EName,
                            Role = j.Role,
                            Emp = new ObservableCollection<JoinTree>()
                        });


                    }
                }

                else if (j.Role.ToLower().Trim() == "dlead")
                {
                    if (JoinTree2.Count == 1)
                    {
                        int flag = 0;
                        foreach (var jj in JoinTree2[0].Emp)
                        {
                            if (jj.Role.ToLower().Trim() == "dlead")
                            {
                                jj.EName = j.EName;
                                flag = 1;
                            }
                        }

                        if (flag == 0)
                        {
                            JoinTree2[0].Emp.Add(new JoinTree()
                            {
                                EName = j.EName,
                                Role = j.Role,
                                Emp = new ObservableCollection<JoinTree>()
                            });
                        }
                    }
                    else
                    {
                        JoinTree2.Add(new JoinTree()
                        {
                            EName = "",
                            Emp = new ObservableCollection<JoinTree>()
                        });
                        JoinTree2[0].Emp.Add(new JoinTree()
                        {
                            EName = j.EName,
                            Role = j.Role,
                            Emp = new ObservableCollection<JoinTree>()
                        });


                    }
                }

                else if (j.Role.ToLower().Trim() == "developer")
                {
                    if (JoinTree2.Count == 1)
                    {
                        if (JoinTree2[0].Emp.Count > 0)
                        {
                            int flag = 0;
                            foreach (var jj in JoinTree2[0].Emp)
                            {
                                if (jj.Role.ToLower().Trim() == "dlead")
                                {
                                    jj.Emp.Add(new JoinTree()
                                    {
                                        EName = j.EName,
                                        Role = j.Role
                                    });

                                    flag = 1;
                                }
                            }
                            if (flag == 0)
                            {
                                JoinTree2[0].Emp.Add(new JoinTree()
                                {
                                    EName = "",
                                    Role = "DLead",
                                    Emp = new ObservableCollection<JoinTree>
                                    {
                                        new JoinTree()
                                        {
                                            EName = j.EName,
                                            Role = j.Role
                                        }
                                    }

                                });
                            }
                        }
                        else
                        {
                            JoinTree2[0].Emp.Add(new JoinTree()
                            {
                                EName = "",
                                Role = "DLead",
                                Emp = new ObservableCollection<JoinTree>
                                {
                                    new JoinTree()
                                    {
                                        EName = j.EName,
                                        Role = j.Role
                                    }
                                }
                            });
                        }

                    }
                    else
                    {
                        JoinTree2.Add(new JoinTree()
                        {
                            EName = "",
                            Emp = new ObservableCollection<JoinTree>()
                            {
                                new JoinTree()
                                {
                                    EName = "",
                                    Role = "DLead",
                                    Emp = new ObservableCollection<JoinTree>(){
                                        new JoinTree()
                                        {
                                            EName = j.EName,
                                            Role = j.Role
                                        }
                                    }
                                }
                            }
                        });
                    }
                    
                }


                else if (j.Role.ToLower().Trim() == "tester")
                {
                    if (JoinTree2.Count == 1)
                    {
                        if (JoinTree2[0].Emp.Count > 0)
                        {
                            int flag = 0;
                            foreach (var jj in JoinTree2[0].Emp)
                            {
                                if (jj.Role.ToLower().Trim() == "tlead")
                                {
                                    jj.Emp.Add(new JoinTree()
                                    {
                                        EName = j.EName,
                                        Role = j.Role
                                    });

                                    flag = 1;
                                }
                            }
                            if (flag == 0)
                            {
                                JoinTree2[0].Emp.Add(new JoinTree()
                                {
                                    EName = "",
                                    Role = "TLead",
                                    Emp = new ObservableCollection<JoinTree>
                                    {
                                        new JoinTree()
                                        {
                                            EName = j.EName,
                                            Role = j.Role
                                        }
                                    }

                                });
                            }
                        }
                        else
                        {
                            JoinTree2[0].Emp.Add(new JoinTree()
                            {
                                EName = "",
                                Role = "TLead",
                                Emp = new ObservableCollection<JoinTree>{
                                    new JoinTree()
                                    {
                                        EName = j.EName,
                                        Role = j.Role
                                    }
                                }
                            });
                        }

                    }
                    else
                    {
                        JoinTree2.Add(new JoinTree()
                        {
                            EName = "",
                            Emp = new ObservableCollection<JoinTree>()
                            {
                                new JoinTree()
                                {
                                    EName = "",
                                    Role = "TLead",
                                    Emp = new ObservableCollection<JoinTree>(){
                                        new JoinTree()
                                        {
                                            EName = j.EName,
                                            Role = j.Role
                                        }
                                    }
                                }
                            }
                        });

                       
                    }
                }


            }

            TreeView2.DataContext = JoinTree2;
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


            TreeView2.DataContext = JoinTree2;

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
        public ObservableCollection<Lead> Leads { get; set; }
    }

    public class Lead
    {
        public string EName { get; set; }
        public ObservableCollection<Join> E { get; set; }

    }

    public class Em
    {
        public string EName { get; set; }
    }


    public class JoinTree
    {
        public string EName { get; set; }
        public int? Eno { get; set; }
        public float? Esalary { get; set; }
        public string Role { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public ObservableCollection<JoinTree> Leads { get; set; }
        public ObservableCollection<JoinTree> Managers { get; set; }

        public ObservableCollection<JoinTree> Dev { get; set; }

        public ObservableCollection<JoinTree> Test { get; set; }


        public ObservableCollection<JoinTree> Emp { get; set; }
    }


}
