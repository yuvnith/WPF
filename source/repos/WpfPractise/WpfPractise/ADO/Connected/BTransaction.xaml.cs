using System;
using System.Collections.Generic;
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
using BankTransactions;

namespace WpfPractise.ADO.Connected
{
    /// <summary>
    /// Interaction logic for BTransaction.xaml
    /// </summary>
    public partial class BTransaction : Window
    {
        public BTransaction()
        {
            InitializeComponent();
        }

        private void btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            int amt = int.Parse(inp_amount.Text);
            int famt = int.Parse(inp_fromacc.Text);
            int tamt = int.Parse(inp_toacc.Text);


            if (MessageBox.Show("are you sure ?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                
              Transaction trans = new Transaction();

               if(trans.update(famt, tamt, amt) == true)
                MessageBox.Show("transfer succsessfull");
                else
                MessageBox.Show("transfer unsuccessful");
            }
        }
    }
}
