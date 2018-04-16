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
    /// Interaction logic for HierarchicalTemplate.xaml
    /// </summary>
    public partial class HierarchicalTemplate : Window
    {
        public ObservableCollection<A> Root =new ObservableCollection<A>();

        public HierarchicalTemplate()
        {
            InitializeComponent();
            Data();
        }


        public void Data()
        {
            A a = new A()
            {
                Name1 = "A",
                
                Coll =  new ObservableCollection<A>()
                {
                    new A()
                    {
                        Name1 = "AA",
                       
                        Coll = new ObservableCollection<A>()
                        {
                            new A()
                            {
                                Name1 = "BBB",
                                Coll = new ObservableCollection<A>()
                                {
                                    new A()
                                    {
                                         Name1 = "ccc"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            Root.Add(a);
            DataContext = Root;
        }

        
    }


    public class A
    {
        public string Name1 { get; set; }
       
        public ObservableCollection<A> Coll { get; set; }
    }
}
