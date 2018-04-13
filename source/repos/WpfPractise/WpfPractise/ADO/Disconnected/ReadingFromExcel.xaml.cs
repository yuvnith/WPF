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
using System.Data;
using System.Data.OleDb;

namespace WpfPractise.ADO.Disconnected
{
    /// <summary>
    /// Interaction logic for ReadingFromExcel.xaml
    /// </summary>
    public partial class ReadingFromExcel : Window
    {
        public ReadingFromExcel()
        {
            InitializeComponent();
            read();
        }


        public void read()
        {
            string FileName = "d:/mat.cs";
            string cs= @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\mat.cs;Extended Properties=Excel 8.0; HDR = Yes; IMEX = 1";
            OleDbConnection cn = new OleDbConnection(cs);
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [4]",cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "mat");
            dg.DataContext = ds.Tables[0];
        }
    }
}
