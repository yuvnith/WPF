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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPractise.ADO.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Employee_click(object sender, RoutedEventArgs e)
        {
            //Uri uri = new Uri("EmployeeCRUD.xaml", UriKind.Relative);
            //NavigationService?.Navigate(uri);
            //NavigationService ns = NavigationService.GetNavigationService(this);
            ////ns.Navigate(new Uri("EmployeeCRUD.xaml", UriKind.RelativeOrAbsolute));
            //ns.Source = new Uri("EmployeeCRUD.xaml", UriKind.Relative);
            //ns.Content = new Uri("EmployeeCRUD.xaml", UriKind.Relative);
        }
    }
}
