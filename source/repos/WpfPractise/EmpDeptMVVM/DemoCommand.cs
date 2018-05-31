using System;
using System.Windows;
using System.Windows.Input;

namespace EmpDeptMVVM
{
    public class DemoCommand :ICommand
    {
        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("command");
        }

        public event EventHandler CanExecuteChanged;
    }
}