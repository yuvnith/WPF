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
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public ObservableCollection<Student> Coll { get; set; }
        public DataGrid()
        {
            InitializeComponent();


            Coll = new ObservableCollection<Student>()
            {
                new Student(){Name = "vamshi",Age = "21",Location = "Hyderabad",Id = "1"},
                new Student(){Name = "krishna",Age = "22",Location = "Hyderabad",Id = "2"},
                new Student(){Name = "D",Age = "20",Location = "Hyd",Id = "3"},
            };

            this.DataContext = Coll;
            Student s = new Student() {Name = "asdas"};

           

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var s=new Student() {Id = Id.Text, Age = Age.Text, Location = Location.Text, Name = Name.Text};
            Coll.Add(s);
            Id.Text = "";
            Name.Text = "";
            Location.Text = "";
            Age.Text = "";
        }
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Age { get; set; }
    }
}
