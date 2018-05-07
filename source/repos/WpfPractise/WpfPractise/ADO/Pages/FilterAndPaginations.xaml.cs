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
    /// Interaction logic for FilterAndPaginations.xaml
    /// </summary>
    public partial class FilterAndPaginations : Page
    {
        private int no = 0;
        OracleConnection connection;
        int flag = 0;
        OracleCommand command;
        int count = 0, noofpages = 0, curr = 0;
        public ObservableCollection<Join> JoinCol { get; set; } = new ObservableCollection<Join>();

        public ObservableCollection<Join> JoinCol2 { get; set; } = new ObservableCollection<Join>();
        public FilterAndPaginations()
        {
            InitializeComponent();


            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            for (int i = 1; i <= 10; i++)
                inp_noofrows.Items.Add(i);

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

            for (int i = 0; i < 100000; i++)
            {
                JoinCol.Add(new Join()
                {
                    Eno = 1,
                    EName = "Name" + i,
                    Esalary = 10,
                    Role = "dev",
                    DeptId = 1,
                    DeptName = "dname" + i

                });


            }

            dg2.DataContext = null;

            dg2.DataContext = JoinCol;


            flag = 0;


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
                    if (!JoinCol2[i].EName.StartsWith(ena))
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
                        if (JoinCol.Contains(JoinCol2[i]))
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

        private void btn_View2_Click(object sender, RoutedEventArgs e)
        {
            display2();
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
             
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


        private void rbsc(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            no = (int)inp_noofrows.SelectionBoxItem;
        }
    }
}

