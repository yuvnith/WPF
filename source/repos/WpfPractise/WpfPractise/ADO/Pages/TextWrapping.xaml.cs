using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Globalization;
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
    /// Interaction logic for TextWrapping.xaml
    /// </summary>
    public partial class TextWrapping : Page
    {
        OracleConnection connection;
        OracleCommand command;
         int flag = 0;
        public ObservableCollection<Temp> collection2 { get; set; } = new ObservableCollection<Temp>();
        public TextWrapping()
        {
            InitializeComponent();


            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            connection = new OracleConnection(constring);
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            display();
        }
        private void btn_display_Click(object sender, RoutedEventArgs e)
        {
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



        }

        private void UIElement_OnPreviewMouseDown1(object sender, MouseButtonEventArgs e)
        {
           TextBox tb = sender as TextBox;
            
        }
    }

    class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
