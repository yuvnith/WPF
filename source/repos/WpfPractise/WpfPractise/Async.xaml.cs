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
    /// Interaction logic for Async.xaml
    /// </summary>
    public partial class Async : Window
    {
        ObservableCollection<Aa> col = new ObservableCollection<Aa>();
        public Async()
        {
            InitializeComponent();
            Gd1.DataContext = col;
            gd1();
        }


        public async Task gd1()
        {
           


            await Task.Run(() =>
            {
                for (var i = 0; i < 10000000; i++)
                {
                    col.Add(new Aa()
                    {
                        no = i
                    });
                }
            });

        }
    }

    public class Aa
    {
        public int no {
            get;
            set;
        }
    }
}
