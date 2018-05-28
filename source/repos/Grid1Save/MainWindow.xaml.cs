using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Reflection;
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

namespace Grid1Save
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        OracleConnection connection;
        OracleCommand command;
        public ObservableCollection<Emp> collection2 { get; set; } = new ObservableCollection<Emp>();
        //public ObservableCollection<Emp> collection3 { get; set; } = new ObservableCollection<Emp>();
        public List<Emp> collection3 { get; set; } = new List<Emp>();
        public MainWindow()
        {

            InitializeComponent();
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            display();
            dg.DataContext = this;
            abc();
        }

        public void abc()
        {

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

                collection2.Add(new Emp
                {
                    EName = dataTableRow.ItemArray[1].ToString(),
                    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                    Esalary = float.Parse(dataTableRow.ItemArray[2].ToString()),
                    Role = dataTableRow.ItemArray[3].ToString(),
                    DeptId = int.Parse(dataTableRow.ItemArray[4].ToString())
                });
                collection3.Add(new Emp
                {
                    EName = dataTableRow.ItemArray[1].ToString(),
                    Eno = int.Parse(dataTableRow.ItemArray[0].ToString()),
                    Esalary = float.Parse(dataTableRow.ItemArray[2].ToString()),
                    Role = dataTableRow.ItemArray[3].ToString(),
                    DeptId = int.Parse(dataTableRow.ItemArray[4].ToString())
                });
            }

        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            //var res_1 = collection2.Select(x => x.Details.Select(x1 => x1));
            //var res_2 = collection3.Select(x => x.Details.Select(x1 => x1));
            //var res_3 = res_1.GetEnumerator();
            //var res_4 = res_2.GetEnumerator();
            //while (res_3.MoveNext())
            //{

            //}
            bool flag = true;
            for (int i = 0; i < collection2.Count(); i++)
            {
                var haveSameData = false;
                foreach (PropertyInfo prop in collection3[i].GetType().GetProperties())
                {
                    haveSameData = prop.GetValue(collection3[i], null).Equals(prop.GetValue(collection2[i], null));

                    if (!haveSameData)
                        break;
                }
                if (!haveSameData)
                {
                    flag = false;
                    break;
                }

            }
            if (flag == true)
            {
                MessageBox.Show("equal");
            }
            else
            {
                MessageBox.Show("not equal");
            }

        }
    }

    public class Temp
    {
        public string EName { get; set; }
        public ObservableCollection<Emp> Details { get; set; }
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
