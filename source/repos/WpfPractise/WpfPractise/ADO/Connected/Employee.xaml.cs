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

namespace WpfPractise.ADO.Connected
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
         OracleConnection connection;
         OracleCommand command;
        public Employee()
        {
            InitializeComponent();

            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType=CommandType.Text;
            display();
        }

        public void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string name = inp_name.Text;
            int salary = int.Parse(inp_salary.Text);
            int no = int.Parse(inp_no.Text);
            command.Parameters.Clear();
            command.CommandText = "insert into Employees (EMPNO,ENAME,SALARY) values(:EMPNO,:ENAME,:SALARY)";
            command.Parameters.AddWithValue("EMPNO", no);
            command.Parameters.AddWithValue("ENAME", name);
            command.Parameters.AddWithValue("SALARY", salary);
            if(connection.State == ConnectionState.Closed)
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
            dg.DataContext = dataTable;

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
            int salary = int.Parse(inp_salary.Text);
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
}
