using System;
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

        public ObservableCollection<Emp> collection { get; set; } = new ObservableCollection<Emp>();
        public ObservableCollection<Temp> collection2 { get; set; }= new ObservableCollection<Temp>();

        public Employee()
        {
            InitializeComponent();


            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            display();


        }

        public void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string name = inp_name.Text;
            float salary = float.Parse(inp_salary.Text);
            int no = int.Parse(inp_no.Text);
            command.Parameters.Clear();
            command.CommandText = "insert into Employees (EMPNO,ENAME,SALARY) values(:EMPNO,:ENAME,:SALARY)";
            command.Parameters.AddWithValue("EMPNO", no);
            command.Parameters.AddWithValue("ENAME", name);
            command.Parameters.AddWithValue("SALARY", salary);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            display();

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

            collection.Clear();
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
                            Esalary = float.Parse(dataTableRow.ItemArray[2].ToString())
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
            dg.DataContext = dataTable;

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
            inp_no.Text = "";
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            string name = inp_name.Text;
            float salary = float.Parse(inp_salary.Text);
            int no = int.Parse(inp_no.Text);
            command.Parameters.Clear();
            command.CommandText = "update Employees set ENAME=:ename,SALARY=:salary where EMPNO =:empno ";
            command.Parameters.AddWithValue("EMPNO", no);
            command.Parameters.AddWithValue("ENAME", name);
            command.Parameters.AddWithValue("SALARY", salary);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            display();

            inp_no.Text = "";
            inp_name.Text = "";
            inp_salary.Text = "";
        }
    }

    public class Emp
    {
        public string EName { get; set; }
        public int? Eno { get; set; }
        public float? Esalary { get; set;}

       
    }

    public class Temp
    {
        public string EName { get; set; }
        public ObservableCollection<Emp> Details { get; set; } 
    }




}
