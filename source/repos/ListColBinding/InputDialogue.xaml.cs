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

namespace ListColBinding
{
    /// <summary>
    /// Interaction logic for InputDialogue.xaml
    /// </summary>
    public partial class InputDialogue : Window
    {
        private MainWindow mainWindow;
        public InputDialogue()
        {
            InitializeComponent();
        }

        public InputDialogue(MainWindow mw)
        {
            InitializeComponent();
            mainWindow = mw;
        }

        private void inp_add_Click(object sender, RoutedEventArgs e)
        {
             Join join = new Join()
             {
                 DeptName = inp_deptName1.Text,
                 DeptId = int.Parse(inp_deptid.Text),
                 EName = inp_name.Text,
                 Eno = int.Parse(inp_no.Text),
                 Esalary = int.Parse(inp_salary.Text),
                 Role = inp_role.Text
             };

             mainWindow.Data.Add(join);

            var data = mainWindow.Data;
            mainWindow.Data = null;
            mainWindow.Data = data;
            mainWindow.OnPropertyChanged(nameof(mainWindow.Data));
            this.Close();
        }

        private void inp_cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
