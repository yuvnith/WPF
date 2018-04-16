using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPractise
{
    /// <summary>
    /// Interaction logic for TreeViewDataBindingSample.xaml
    /// </summary>
    public partial class TreeViewDataBindingSample : Window
    {
        public TreeViewDataBindingSample()
        {
            InitializeComponent();

            MenuItem2 root = new MenuItem2() { Title = "Menu" };
            MenuItem2 childItem1 = new MenuItem2() { Title = "Child item #1" };
            childItem1.Items.Add(new MenuItem2() { Title = "Child item #1.1" });
            childItem1.Items.Add(new MenuItem2() { Title = "Child item #1.2" });
            root.Items.Add(childItem1);
            root.Items.Add(new MenuItem2() { Title = "Child item #2" });
            trvMenu.Items.Add(root);
        }
    }

    public class MenuItem2
    {
        public MenuItem2()
        {
            this.Items = new ObservableCollection<MenuItem2>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem2> Items { get; set; }
    }
}
