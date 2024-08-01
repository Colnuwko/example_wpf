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
   
    }

}