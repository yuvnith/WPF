using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ListColBinding.Annotations;

namespace ListColBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private List<Join> _data = new List<Join>();
        public List<Join> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        public MainWindow()
        {
           InitializeComponent();
            Data.Add(new Join
            {
                DeptName = "asd",
                EName = "asd",
                DeptId = 2,
                Eno = 2,
                Role = "asd",
                Esalary = 3
            });

            dg.DataContext = this;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            InputDialogue id = new  InputDialogue(this);
            id.ShowDialog();
        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Join : INotifyPropertyChanged
    {
        private string _eName;
        private int? _eno;
        private float? _esalary;
        private string _role;
        private int? _deptId;
        private string _deptName;

        public string EName
        {
            get => _eName;
            set
            {
                _eName = value;
                //RaisePropertyChanged(nameof(EName));

            }
        }

        public int? Eno
        {
            get => _eno;
            set
            {
                _eno = value;
                //RaisePropertyChanged("Eno");

            }
        }

        public float? Esalary
        {
            get => _esalary;
            set
            {
                _esalary = value;
                //RaisePropertyChanged("Esalary");

            }
        }

        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                //RaisePropertyChanged("Role");
            }
        }

        public int? DeptId
        {
            get => _deptId;
            set
            {
                _deptId = value;
                //RaisePropertyChanged("DeptId");
            }
        }

        public string DeptName
        {
            get => _deptName;
            set
            {
                _deptName = value;
                //RaisePropertyChanged("DeptName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
