using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfPractise
{
    /// <summary>
    /// Interaction logic for CopyCommand.xaml
    /// </summary>
    public partial class CopyCommand : Window
    {
        
        public CopyCommand()
        {
            InitializeComponent();

            CommandBinding copy = new CommandBinding(ApplicationCommands.Copy);
            this.CommandBindings.Add(copy);
            copy.Executed += new ExecutedRoutedEventHandler(copy_executed);

            CommandBinding paste = new CommandBinding(ApplicationCommands.Paste);
            this.CommandBindings.Add(paste);
            paste.Executed += new ExecutedRoutedEventHandler(paste_executed);
        }

        public void copy_executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("copied");
        }
        public void paste_executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("pasted");
        }
    }
}
