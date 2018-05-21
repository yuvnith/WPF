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
    /// Interaction logic for Tabs.xaml
    /// </summary>
    public partial class Tabs : Page
    {
        public Tabs()
        {
            InitializeComponent();
        }

        private void BtnEmloyee_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = new TabItem();
            
            tabItem.Header = "Tree";
            
            Frame tabFrame = new Frame();
            
            tabFrame.Content = new Tree();
            
            tabItem.Content = tabFrame;
            
            TabControl.Items.Add(tabItem);
            
            TabControl.SelectedItem = tabItem;
        }

        private void BtnDept_OnClick(object sender, RoutedEventArgs e)
        {
            TabItem tabItem1 = new TabItem();
            Frame tabFrame1 = new Frame();
            tabFrame1.Content = new Employee();
            tabItem1.Header = "Employee";
            tabItem1.Content = tabFrame1;
            TabControl.Items.Add(tabItem1);
            TabControl.SelectedItem = tabItem1;
        }
    }
}
