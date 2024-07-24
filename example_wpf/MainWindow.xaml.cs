using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^\-?\d*\.?\d*$");
            e.Handled = !regex.IsMatch(e.Text);
            
        } // Сомневаюсь что ограничение ввода не нарушает MVVM, надеюсь умные люди в интернете не наврали :)

        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }

}