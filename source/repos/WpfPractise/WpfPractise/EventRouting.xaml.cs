using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for EventRouting.xaml
    /// </summary>
    public partial class EventRouting : Window
    {
        public EventRouting()
        {
            InitializeComponent();

            this.MouseEnter += MouseEnterHandler;
            border.MouseEnter += MouseEnterHandler;
            panel.MouseEnter += MouseEnterHandler;
            rectangle.MouseEnter += MouseEnterHandler;
            ellipse.MouseEnter += MouseEnterHandler;

            this.MouseDown += MouseDownHandler;
            border.MouseDown += MouseDownHandler;
            panel.MouseDown += MouseDownHandler;
            rectangle.MouseDown += MouseDownHandler;
            ellipse.MouseDown += MouseDownHandler;

        }

        public void MouseEnterHandler(object sender, MouseEventArgs e)
        {
           Debug.WriteLine("MouseEnter: "+sender);

        }
        public void MouseDownHandler(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("MouseDown: " + sender);
            e.Handled = true; 
        }
    }
}
