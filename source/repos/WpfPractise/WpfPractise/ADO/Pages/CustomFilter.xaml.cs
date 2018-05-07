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

namespace WpfPractise.ADO.Pages
{
    /// <summary>
    /// Interaction logic for CustomFilter.xaml
    /// </summary>
    public partial class CustomFilter : Window
    {
        private int flag = 1;
        List<CusFilterProp> Data = new List<CusFilterProp>();
        List<Controls> ControlsData = new List<Controls>();
        public CustomFilter()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            
            StackPanel sp = new StackPanel(){Orientation = Orientation.Horizontal};

            sp.Children.Add(new Label()
            {
                Content = "Columns:"
            });

            ComboBox cb = new ComboBox()
            {
                Width = 80,
                Name = "cb_columns" + flag,
                Items = { "Ename", "Eno", "Esalary", "Role", "DepId", "DeptName" }
            };
            sp.Children.Add(cb);

            sp.Children.Add(new Label()
            {
                Content = "Value:"
            });

            TextBox tb = new TextBox()
            {
                Width = 80,
                Name = "inp_value" + flag
            };

            sp.Children.Add(tb);
            
            sp.Children.Add(new Label()
            {
                Content = "Type:"
            });

            ComboBox cb2 = new ComboBox()
            {
                Width = 80,
                Name = "cb_Type" + flag,
                Items = { "StartsWith", "EndsWith", "EqualTo" }
            };

            sp.Children.Add(cb2);
     
            StackPanel1.Children.Add(sp);

            flag++;

            ControlsData.Add(new Controls()
            {
                Column = cb,
                Type = cb2,
                Value = tb
            });
        }
        
        public void Filter()
        {
            Filters2 obj = new Filters2();
            Filters2.JoinCol.Clear();


            foreach (var j in obj.JoinCol2)
            {
                Filters2.JoinCol.Add(j);
            }

            foreach (var c in ControlsData)
            {
                if(c.Column.Text == "Ename")
                    Ename(c.Value.Text,c.Type.Text,obj);

                else if (c.Column.Text == "Eno")
                    Eno(c.Value.Text, c.Type.Text,obj);

                else if (c.Column.Text == "Esalary")
                    Esalary(c.Value.Text, c.Type.Text,obj);

                else if (c.Column.Text == "Role")
                    Role(c.Value.Text, c.Type.Text,obj);

                else if (c.Column.Text == "DepId")
                    DepId(c.Value.Text, c.Type.Text,obj);

                else if (c.Column.Text == "DeptName")
                    DeptName(c.Value.Text, c.Type.Text,obj);
            }


        }

        public void Ename(string val,string type,Filters2 obj)
        {
            if (type == "StartsWith")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (!obj.JoinCol2[i].EName.StartsWith(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
            else if(type == "EndsWith")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (!obj.JoinCol2[i].EName.EndsWith(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
            else if (type == "EqualTo")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (obj.JoinCol2[i].EName != val)
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
        }
        public void DepId(string val, string type, Filters2 obj)
        {

            if (type == "EqualTo")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (obj.JoinCol2[i].DeptId != int.Parse(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
        }

        public void DeptName(string val, string type, Filters2 obj)
        {
            if (type == "StartsWith")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (!obj.JoinCol2[i].DeptName.StartsWith(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
            else if (type == "EndsWith")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (!obj.JoinCol2[i].DeptName.EndsWith(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
            else if (type == "EqualTo")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (obj.JoinCol2[i].DeptName != val)
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
        }
        public void Esalary(string val, string type, Filters2 obj)
        {
            if (type == "EqualTo")
             {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (obj.JoinCol2[i].Esalary != double.Parse(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
        }
        public void Role(string val, string type, Filters2 obj)
        {
            if (type == "StartsWith")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (!obj.JoinCol2[i].Role.StartsWith(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
            else if (type == "EndsWith")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (!obj.JoinCol2[i].Role.EndsWith(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
            else if (type == "EqualTo")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (obj.JoinCol2[i].Role != val)
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
        }
        public void Eno(string val, string type, Filters2 obj)
        {
            if (type == "EqualTo")
            {
                for (int i = 0; i < obj.JoinCol2.Count; i++)
                {
                    if (obj.JoinCol2[i].Eno != int.Parse(val))
                    {
                        if (Filters2.JoinCol.Contains(obj.JoinCol2[i]))
                            Filters2.JoinCol.Remove(obj.JoinCol2[i]);
                    }
                }
            }
        }

        private void btn_apply_Click(object sender, RoutedEventArgs e)
        {
            Filter();
            this.Close();
        }
    }

    public class CusFilterProp
    {
         public string ColName { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Controls
    {
        public TextBox Value { get; set; }
        public ComboBox Type { get; set; }
        public ComboBox Column { get; set; }
    }
}
