using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {

        OracleConnection connection;
        OracleCommand command;

        ObservableCollection<Emp> col = new ObservableCollection<Emp>();
        public Form1()
        {
            InitializeComponent();
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            display();
        }




       
        private void btn_ISearch_Click_1(object sender, EventArgs e)
        {
            col.Clear();
            command.Parameters.Clear();
            command.CommandText = "select * from Employees where EMPNO = :empno";
            command.Parameters.AddWithValue("empno", int.Parse(inp_id.Text));
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            foreach (DataRow dataTableRow in dataTable.Rows)
            {
               col.Add(new Emp()
               {
                   EName = dataTableRow.ItemArray[1].ToString(),
                   Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                   Role = dataTableRow.ItemArray[3].ToString(),
                   Esalary = int.Parse(dataTableRow.ItemArray[2].ToString()),
                   DeptId = int.Parse(dataTableRow.ItemArray[4].ToString()),
               });
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = col;
        }

        private void btn_NSearch_Click_1(object sender, EventArgs e)
        {
            col.Clear();
            command.Parameters.Clear();
            command.CommandText = "select * from Employees where EName = :EName";
            command.Parameters.AddWithValue("EName", (inp_name.Text));
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                col.Add(new Emp()
                {
                    EName = dataTableRow.ItemArray[1].ToString(),
                    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                    Role = dataTableRow.ItemArray[3].ToString(),
                    Esalary = int.Parse(dataTableRow.ItemArray[2].ToString()),
                    DeptId = int.Parse(dataTableRow.ItemArray[4].ToString()),
                });
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = col;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public void display()
        {
            col.Clear();
            command.Parameters.Clear();
            command.CommandText = "select * from Employees";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            OracleDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);

            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                col.Add(new Emp()
                {
                    EName = dataTableRow.ItemArray[1].ToString(),
                    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                    Role = dataTableRow.ItemArray[3].ToString(),
                    Esalary = int.Parse(dataTableRow.ItemArray[2].ToString()),
                    DeptId = int.Parse(dataTableRow.ItemArray[4].ToString()),
                });
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = col;
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            display();
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
}
