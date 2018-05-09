using System;
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
using System.Windows.Shapes;

namespace WpfPractise
{
    /// <summary>
    /// Interaction logic for ControlExpansion.xaml
    /// </summary>
    public partial class ControlExpansion : Window
    {
         int flag = 0 ,focus = 0;

      

        public ControlExpansion()
        {
            InitializeComponent();
        }


        private void Tb_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Tb.Height += 100;
        }
    }
}
