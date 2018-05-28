using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {

        OracleConnection connection;
        OracleCommand command;
        public ObservableCollection<Temp> collection2 { get; set; } = new ObservableCollection<Temp>();



        public string Name { get; set; }
        public int Salary { get; set; }



        public Employee()
        {
            InitializeComponent();


            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            dg.DataContext = null;
            dg.DataContext = collection2;

            display();

            inp_name.DataContext = this;
            inp_salary.DataContext = this;
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

        }

        public async Task display()
        {

            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Dispatcher.Invoke(() =>
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
                });

            });
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

            inp_no.Text = "";
            inp_name.Text = "";
            inp_salary.Text = "";
        }
    }

    public class NameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if((string) value == "")
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (value.ToString().Length > 10)
                    return new ValidationResult
                        (false, "Name cannot be more than 10 characters long.");
            }
            return ValidationResult.ValidResult;
        }
    }

    public class SalaryValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ((string)value == "")
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                int a;
                var res = int.TryParse(value.ToString(), out a);
                if (!res)
                    return new ValidationResult
                        (false, "enter valid salary");
            }
            return ValidationResult.ValidResult;
        }
    }
}
