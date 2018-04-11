using System;
using System.Windows;
using System.Windows.Input;

namespace WpfPractise
{
    public class MyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter.ToString().Length > 2)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show(parameter.ToString().ToUpper());
        }

        public event EventHandler CanExecuteChanged;
    }
}