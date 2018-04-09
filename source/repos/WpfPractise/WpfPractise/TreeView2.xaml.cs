using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfPractise
{
    /// <summary>
    /// Interaction logic for TreeView2.xaml
    /// </summary>
    public partial class TreeView2 : Window
    {
        public TreeView2()
        {
            InitializeComponent();
            MenuItem root = new MenuItem() { Title = "Menu" };
            MenuItem childItem1 = new MenuItem() { Title = "Vamshi" };
            childItem1.Items.Add(new MenuItem() { Age = "21"});
            childItem1.Items.Add(new MenuItem() { Location = "Hyd"});
            root.Items.Add(childItem1);
            root.Items.Add(new MenuItem() { Title = "Child item #2" });
            trvMenu.Items.Add(root);
        }
    }
    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public string Age { get; set; }
        public string Location { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }


}
