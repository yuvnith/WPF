using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Diagnostics;


namespace WpfPractise.ADO.Disconnected
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        public Employee()
        {
            InitializeComponent();
            display();

           
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            OracleDataAdapter adapter = new OracleDataAdapter("select * from Employees", connection);
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds,"Employees");

            DataRow row = ds.Tables[0].NewRow();

            row["EMPNO"] = inp_no.Text;
            row["ENAME"] = inp_name.Text;
            row["SALARY"] = inp_salary.Text;

            ds.Tables[0].Rows.Add(row);
            adapter.Update(ds.Tables[0]);
            inp_name.Text = "";
            inp_no.Text = "";
            inp_salary.Text = "";



            display();

        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            display();
        }

        public void display()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            OracleDataAdapter adapter = new OracleDataAdapter("select * from Employees", connection);
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employees");


            dg.DataContext = ds.Tables[0];
        }

        private void btn_Find_Click(object sender, RoutedEventArgs e)
        {
            int empno = int.Parse(inp_FindNo.Text);

            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            OracleDataAdapter adapter = new OracleDataAdapter("select * from Employees", connection);
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employees");

            ds.Tables[0].Constraints.Add("empno_pk", ds.Tables[0].Columns["empno"], true);

            if (ds.Tables[0].Rows.Contains(empno) == true)
            {
                DataRow row = ds.Tables[0].Rows.Find(empno);
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Salary");
                dt.Rows.Add(row.ItemArray);
                dg.DataContext = null;
                dg.DataContext = dt;


                


            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            int empno = int.Parse(inp_no.Text);

            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            OracleDataAdapter adapter = new OracleDataAdapter("select * from Employees", connection);
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employees");

            ds.Tables[0].Constraints.Add("empno_pk", ds.Tables[0].Columns["empno"], true);

            if (ds.Tables[0].Rows.Contains(empno) == true)
            {
                DataRow row = ds.Tables[0].Rows.Find(empno);
                row.BeginEdit();
                row[1] = inp_name.Text;
                row[2] = inp_salary.Text;
                row.EndEdit();
                adapter.Update(ds.Tables[0]);


                inp_name.Text = "";
                inp_no.Text = "";
                inp_salary.Text = "";

                display();
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int empno = int.Parse(inp_FindNo.Text);

            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            OracleConnection connection = new OracleConnection(constring);
            OracleDataAdapter adapter = new OracleDataAdapter("select * from Employees", connection);
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employees");

            ds.Tables[0].Constraints.Add("empno_pk", ds.Tables[0].Columns["empno"], true);

            if(MessageBox.Show("Are you sure you want to delete the record ?","Delete",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            if (ds.Tables[0].Rows.Contains(empno) == true)
            {
                ds.Tables[0].Rows.Find(empno).Delete();
                adapter.Update(ds.Tables[0]);

                inp_name.Text = "";
                inp_no.Text = "";
                inp_salary.Text = "";

                inp_FindNo.Text = "";

                display();
            }
        }
    }
}
