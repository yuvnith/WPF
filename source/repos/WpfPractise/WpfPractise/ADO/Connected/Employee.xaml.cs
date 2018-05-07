    using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Globalization;
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
    public partial class Employee
    {
        OracleConnection connection;
        OracleCommand command;

        //data grid text box value change 
        int flag = 0;

        //  public ObservableCollection<Emp> collection { get; set; } = new ObservableCollection<Emp>();
        public ObservableCollection<Temp> collection2 { get; set; } = new ObservableCollection<Temp>();

        public ObservableCollection<Temp1> DeptCol { get; set; } = new ObservableCollection<Temp1>();

        public ObservableCollection<Join> JoinCol { get; set; } = new ObservableCollection<Join>();

        public ObservableCollection<Join> JoinCol2 { get; set; } = new ObservableCollection<Join>();

        public ObservableCollection<Join> FilterCol { get; set; } = new ObservableCollection<Join>();

        public ObservableCollection<Manager> JoinTree { get; set; } = new ObservableCollection<Manager>();


        public ObservableCollection<JoinTree> JoinTree2 { get; set; } = new ObservableCollection<JoinTree>();

        //pagination
        int count = 0, noofpages = 0, curr = 0;

        public Employee()
        {
            InitializeComponent();



            for (int i = 1; i <= 10; i++)
                inp_noofrows.Items.Add(i);

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





            //for (int i = 0; i < 100; i++)
            //{
            //    JoinCol.Add(new Join()
            //    {
            //        EName = i.ToString(),
            //        Role = "developer",
            //        Eno = i,
            //        Esalary = 10,
            //        DeptName = "ERM",
            //        DeptId = 1
            //    });
            //}

            JoinCol2 = new ObservableCollection<Join>(JoinCol);

            dg2.DataContext = null;

            dg2.DataContext = JoinCol;



            //if (dg2.DataContext == null)
            //{
            //    //dg2.Items.Clear();
            //    dg2.DataContext = JoinCol;
            //}
            Tree3();

            flag = 0;


        }


        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                flag = 1;
                dg2.ItemsSource = null;
                dg2.Items.Add(new Join()
                {
                    DeptId = null,
                    EName = "",
                    Role = "",
                    Eno = null,
                    Esalary = null,
                    DeptName = ""
                });




            }

        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (flag == 1)
            {
                TextBox tb = sender as TextBox;
                string name = tb.Text;

                var list = JoinCol.Where(s => s.EName.StartsWith(name));
                var er = list.GetEnumerator();
                er.MoveNext();

                FilterCol.Clear();
                foreach (var l in list)
                {
                    FilterCol.Add(new Join()
                    {
                        EName = er.Current.EName,
                        Role = er.Current.Role,
                        Eno = er.Current.Eno,
                        Esalary = er.Current.Esalary,
                        DeptName = er.Current.DeptName,
                        DeptId = er.Current.DeptId

                    });
                    er.MoveNext();
                }


                foreach (var f in FilterCol)
                {
                    dg2.Items.Add(f);
                }

            }
            // flag = 1;
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

        private void btn_View2_Click(object sender, RoutedEventArgs e)
        {
            display2();
        }


        private void TextBoxBase_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (flag == 1)
            {
                TextBox tb = sender as TextBox;
                string name = tb.Text;

                FilterCol.Clear();
                for (int i = 0; i < JoinCol.Count; i++)
                {
                    if (JoinCol[i].EName.StartsWith(name))
                        FilterCol.Add(JoinCol[i]);
                }

                int c = dg2.Items.Count;
                for (int i = c - 1; i > 0; i--)
                {
                    dg2.Items.RemoveAt(i);
                }
                foreach (var f in FilterCol)
                {
                    dg2.Items.Add(f);
                }




            }
        }

        private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string sal = tb.Text;



            //foreach (var f in FilterCol)
            //{
            //    if (f.Esalary.ToString() != sal)
            //        FilterCol.Remove(f);
            //}

            for (int j = 0; j < FilterCol.Count; j++)
            {
                if (FilterCol[j].EName.ToString() != sal)
                    FilterCol.RemoveAt(j);

            }



            for (int i = 0; i < FilterCol.Count; i++)
            {
                if (FilterCol[i].Esalary.ToString() != sal)
                    FilterCol.RemoveAt(i);
            }



            int c = dg2.Items.Count;
            for (int i = c - 1; i > 0; i--)
            {
                dg2.Items.RemoveAt(i);
            }

            foreach (var f in FilterCol)
            {
                dg2.Items.Add(f);
            }


        }

      


       


        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            //int no = int.Parse(inp_noofrows.Text);

            int gridh = int.Parse(Math.Abs(dg2.Height).ToString());
            double headerh = (Math.Abs(dg2.ColumnHeaderHeight));


            int no2 = int.Parse(Math.Round(dg2.Height).ToString())-int.Parse(Math.Round(dg2.ColumnHeaderHeight).ToString());

            int cellh = int.Parse(Math.Round(dg2.RowHeight).ToString());
            int no = no2 / cellh;
            int from = curr;
            int to = curr + no;
            if (to < JoinCol2.Count)
            {
                JoinCol.Clear();

                int i = 0;
                for (i = from; i < to; i++)
                {
                    JoinCol.Add(JoinCol2[i]);
                }

                curr = i;
            }
            else
            {
                if (from < JoinCol2.Count)
                {
                    JoinCol.Clear();
                    int i = 0;
                    for (i = from; i < JoinCol2.Count; i++)
                    {
                        JoinCol.Add(JoinCol2[i]);
                    }

                    curr = i;
                }
            }
        }

        private void btn_prev_Click(object sender, RoutedEventArgs e)
        {

            int no = int.Parse(inp_noofrows.Text);

            int from = curr - (no + no);
            int to = curr - no;

            if (from > 0)
            {
                JoinCol.Clear();

                int i = 0;
                for (i = from; i < to; i++)
                {
                    JoinCol.Add(JoinCol2[i]);
                }

                curr = i;
            }

            else
            {
                if (to > 0)
                {
                    JoinCol.Clear();
                    int i = 0;
                    for (i = 0; i < to; i++)
                    {
                        JoinCol.Add(JoinCol2[i]);
                    }

                    curr = i;
                }
            }

        }

        private void btn_last_Click(object sender, RoutedEventArgs e)
        {
            JoinCol.Clear();
            int no = int.Parse(inp_noofrows.Text);
            int i = 0;
            for (i = JoinCol2.Count - no; i < JoinCol2.Count; i++)
            {
                JoinCol.Add(JoinCol2[i]);
            }

            curr = JoinCol2.Count;
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            JoinCol.Clear();
            int no = int.Parse(inp_noofrows.Text);
            int i = 0;
            for (i = 0; i < no; i++)
            {
                JoinCol.Add(JoinCol2[i]);
            }
            curr = i;
        }

        private void dg2_Filter_OnTextChanged(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            var colname = tb.DataContext.ToString();
            int flag2 = 0;

            if (colname.ToLower() == "ename")
                ena = tb.Text;
            else if (colname.ToLower() == "esalary")
                esa = tb.Text;
            else if (colname.ToLower() == "role")
                ro = tb.Text;
            else if (colname.ToLower() == "eno")
                eno = tb.Text;
            else if (colname.ToLower() == "deptname")
                dn = tb.Text;
            else if (colname.ToLower() == "deptid")
                di = tb.Text;


            string condition = "select * from employees where ";
            command.Parameters.Clear();
            if (ena != "")
            {
                if (flag2 == 0)
                {
                    condition += " ename Like :ENAME";
                    command.Parameters.AddWithValue("ENAME", ena);
                    flag2 = 1;
                }
                else
                {
                    condition += " and ename Like :ENAME";
                    command.Parameters.AddWithValue("ENAME", ena);
                }

            }
            if (esa != "")
            {
                if (flag2 == 0)
                {
                    condition += " salary=:SALARY";
                    command.Parameters.AddWithValue("SALARY", esa);
                    flag2 = 1;
                }
                else
                {
                    condition += " and salary=:SALARY";
                    command.Parameters.AddWithValue("SALARY", esa);
                }

            }
            if (ro != "")
            {
                if (flag2 == 0)
                {
                    condition += " role like :ROLE";
                    command.Parameters.AddWithValue("ROLE", ro);
                    flag2 = 1;
                }
                else
                {
                    condition += " and role Like :ROLE";
                    command.Parameters.AddWithValue("ROLE", ro);
                }

            }
            if (eno != "")
            {
                if (flag2 == 0)
                {
                    condition += " empno=:EMPNO";
                    command.Parameters.AddWithValue("EMPNO", eno);
                    flag2 = 1;
                }
                else
                {
                    condition += " and empno=:EMPNO";
                    command.Parameters.AddWithValue("EMPNO", eno);
                }

            }
            if (di != "")
            {
                if (flag2 == 0)
                {
                    condition += " deptid=:DEPTID";
                    command.Parameters.AddWithValue("DEPTID", di);
                    flag2 = 1;
                }
                else
                {
                    condition += " and deptid=:DEPTID";
                    command.Parameters.AddWithValue("DEPTID", di);
                }

            }



            command.CommandText = condition;
            if (flag2 == 0)
            {
                command.CommandText = "select * from employees";
            }

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            JoinCol.Clear();
            JoinCol.Clear();
            foreach (DataRow dataTableRow in dataTable.Rows)
            {

                JoinCol.Add(new Join()
                {
                    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                    EName = dataTableRow.ItemArray[1].ToString(),
                    Esalary = int.Parse(dataTableRow.ItemArray[2].ToString()),
                    Role = dataTableRow.ItemArray[3].ToString(),
                    DeptId = int.Parse(dataTableRow.ItemArray[4].ToString())


                });
            }

        }

        private void btn_delete1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_update1_Click(object sender, RoutedEventArgs e)
        {

        }

        string ena = "", eno = "", esa = "", di = "", dn = "", ro = "";


        private void TextBox_OnLostFocus2(object sender, RoutedEventArgs e)
        {
            JoinCol.Clear();
            TextBox tb = sender as TextBox;
            var colname = tb.DataContext.ToString();
            int flag2 = 0;

            if (colname.ToLower() == "ename")
                ena = tb.Text;
            else if (colname.ToLower() == "esalary")
                esa = tb.Text;
            else if (colname.ToLower() == "role")
                ro = tb.Text;
            else if (colname.ToLower() == "eno")
                eno = tb.Text;
            else if (colname.ToLower() == "deptname")
                dn = tb.Text;
            else if (colname.ToLower() == "deptid")
                di = tb.Text;


            foreach (var j in JoinCol2)
            {
                JoinCol.Add(j);
            }

            if (ena != "")
            {
                for (int i = 0; i < JoinCol2.Count; i++)
                {
                    if(!JoinCol2[i].EName.StartsWith(ena))
                    {
                        if (JoinCol.Contains(JoinCol2[i]))
                            JoinCol.Remove(JoinCol2[i]);
                    }
                }
                flag2 = 1;
            }


            if (esa != "")
            {

                for (int i = 0; i < JoinCol2.Count; i++)
                {
                    if (JoinCol2[i].Esalary.ToString().ToLower() != esa.ToLower())
                    {
                        if (JoinCol.Contains(JoinCol2[i]))
                            JoinCol.Remove(JoinCol2[i]);
                    }
                }
                flag2 = 1;
            }


            if (ro != "")
            {
                for (int i = 0; i < JoinCol2.Count; i++)
                {
                    if (!JoinCol2[i].Role.ToLower().StartsWith(ro))
                        if (JoinCol.Contains(JoinCol2[i]))
                            JoinCol.Remove(JoinCol2[i]);
                }
                flag2 = 1;
            }


            if (eno != "")
            {
                for (int i = 0; i < JoinCol2.Count; i++)
                {
                    if (JoinCol2[i].Eno.ToString().ToLower() != eno.ToLower())
                        if(JoinCol.Contains(JoinCol2[i]))
                        JoinCol.Remove(JoinCol2[i]);
                }
                flag2 = 1;
            }

            if (di != "")
            {
                for (int i = 0; i < JoinCol2.Count; i++)
                {
                    if (JoinCol2[i].DeptId.ToString().ToLower() != di.ToLower())
                        if (JoinCol.Contains(JoinCol2[i]))
                            JoinCol.Remove(JoinCol2[i]);
                }
                flag2 = 1;
            }

            if (dn != "")
            {
                for (int i = 0; i < JoinCol.Count; i++)
                {
                    if (!JoinCol2[i].DeptName.ToLower().StartsWith(dn.ToLower()))
                        if (JoinCol.Contains(JoinCol2[i]))
                            JoinCol.Remove(JoinCol2[i]);
                }
                flag2 = 1;
            }


            if (flag2 == 0)
            {
                JoinCol.Clear();
                for (int i = 0; i < JoinCol2.Count; i++)
                {
                    JoinCol.Add(JoinCol2[i]);
                }

            }

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
        public int? DeptId { get; set; }
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

    public class FilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {


                string b = value.ToString();
                if (b.Equals("True"))
                    return Visibility.Visible;

            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class gridHeightconverer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value.ToString() == "True")
                    return "*";
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
