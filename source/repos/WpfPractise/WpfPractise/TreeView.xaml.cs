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
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : Window
    {
        public static ObservableCollection<Students> Coll { get; set; }

        public TreeView()
        {
            InitializeComponent();
            Coll = Data();
            DataContext = Coll;
        }

        public ObservableCollection<Students> Data()
        {
            var data = new ObservableCollection<Students>();

            Students s1 = new Students()
            {
                Name = "vamshi",
                det = new ObservableCollection<Details>()
                {
                        new Details()
                        {
                            Marks = new ObservableCollection<Subjects>()
                            {
                                new Subjects()
                                {
                                    Maths = "100",
                                    Science = "40"
                                }
                            },

                           Info = new ObservableCollection<Personal>()
                           {
                               new Personal()
                               {
                                   Age = "20",
                                   Location = "Hyderabad"
                               }
                           }
                        }

                }
            };
            Students s2 = new Students()
            {
                Name = "krishna",
                det = new ObservableCollection<Details>()
                {
                    new Details()
                    {
                        Marks = new ObservableCollection<Subjects>()
                        {
                            new Subjects()
                            {
                                Maths = "10",
                                Science = "80"
                            }
                        },

                        Info = new ObservableCollection<Personal>()
                        {
                            new Personal()
                            {
                                Age = "22",
                                Location = "Secunderabad"
                            }
                        }
                    }

                }

            };
            data.Add(s1);
            data.Add(s2);
            return data;
        }


    }

    public class Students
    {
        public string Name { get; set; }
        public ObservableCollection<Details> det { get; set; }
    }

    public class Details
    {
        public ObservableCollection<Subjects> Marks { get; set; }
        public ObservableCollection<Personal> Info { get; set; }
    }

    public class Subjects
    {
        public string Maths { get; set; }
        public string Science { get; set; }
    }
    public class Personal
    {
        public string Age { get; set; }
        public string Location { get; set; }
    }
}
