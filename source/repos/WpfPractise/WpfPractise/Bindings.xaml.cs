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
    /// Interaction logic for Bindings.xaml
    /// </summary>
    public partial class Bindings : Window
    {
        Person person = new Person { Name = "Salman", Age = 26 };
        public Bindings()
        {
            InitializeComponent();
            this.DataContext = person;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            person.Name = Tb2.Text;
        }
    }
    public class Person
    {

        private string nameValue;

        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        private double ageValue;

        public double Age
        {
            get { return ageValue; }

            set
            {
                if (value != ageValue)
                {
                    ageValue = value;
                }
            }
        }

    }
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isenable = true;
            if (string.IsNullOrEmpty(value.ToString()))
            {
                isenable = false;
            }
            return isenable;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class CheckBoxCheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().ToUpper() == "MARRIED")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool married = System.Convert.ToBoolean(value);
            if (married == true)
                return "Married";
            else
                return "Unmarried";
        }
    }
}
