﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using WinFormControl;

namespace WpfPractise.ADO.Pages
{
    /// <summary>
    /// Interaction logic for WindowPage.xaml
    /// </summary>
    public partial class WindowPage : Page
    {
        public WindowPage()
        {
            InitializeComponent();
            UserControl1 uc = new UserControl1();
            wfh.Child = uc;
        }
    }
}
