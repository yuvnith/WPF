using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for MyComboBox.xaml
    /// </summary>
    public partial class MyComboBox : UserControl
    {
        public MyComboBox()
        {
            InitializeComponent();
        }
        

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            //Listbox.Items.Clear();
            Listbox.Visibility = Visibility.Visible;
            for (int i = 0; i < 10; i++)
            {
                Listbox.Items.Add(i.ToString());
            }
        }

        private void Listbox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox.Text = Listbox.SelectedItems[0].ToString();
            Listbox.Visibility = Visibility.Hidden;
        }

        public int demo()
        {
            return Listbox.Items.Count;
        }
    }
}
