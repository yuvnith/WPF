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
                        Age = "12",
                        Location = "Himayathnagar",
                        Pin = "500000",
                        Marks = new ObservableCollection<Subjects>()
                        {
                            new Subjects()
                            {
                                Science = "80",
                                Maths = "100"
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
                        Age = "10",
                        Location = "Narayanguda",
                        Pin = "600000",
                        Marks = new ObservableCollection<Subjects>()
                        {
                            new Subjects()
                            {
                                Maths = "100",
                                Science = "90"

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
        public string Age { get; set; }
        public string Location { get; set; }
        public string Pin { get; set; }

        public ObservableCollection<Subjects> Marks { get; set; }
    }

    public class Subjects
    {
        public string Maths { get; set; }
        public string Science { get; set; }
    }
}
