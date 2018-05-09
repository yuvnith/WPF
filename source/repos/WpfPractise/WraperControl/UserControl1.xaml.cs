using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WraperControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        int flag = 1;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void TextBox_PriviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (flag == 1)
            {
                tb.Height += 100;
                flag = 0;
            }
            else if (flag == 0)
            {
                tb.Height -= 100;
                flag = 1;
            }

        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public string Text
        {
            get
            {
                return Tb.Text;
            }

            set
            {
                Tb.Text = value;
            }

        }

    }
}

