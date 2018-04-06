using System;
using System.Collections;
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

namespace WpfPractise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            one.SpellCheck.IsEnabled = true;
            listbox1.Items.Add(123);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello ");
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Validations obj = new Validations();
            obj.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             IList value = listbox1.SelectedItems;
            MessageBox.Show(value[0]+" ");
        }
    }
}
