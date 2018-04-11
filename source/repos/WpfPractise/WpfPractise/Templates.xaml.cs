using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
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
    /// Interaction logic for Templates.xaml
    /// </summary>
    public partial class Templates : Window
    {
        public Templates()
        {
            ObservableCollection<Stud> coll = new ObservableCollection<Stud>()
            {
                new Stud(){Name = "vamshi",Age = "22"},
                new Stud(){Name = "krishna",Age = "21"}
            };
            InitializeComponent();
            this.DataContext = coll;
        }
    }

    class Stud
    {
        public  string Name { get; set; }
        public string Age { get; set; }
    }
}
