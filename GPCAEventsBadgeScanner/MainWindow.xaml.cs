using GPCAEventsBadgeScanner.ViewModel;
using System.Windows;

namespace GPCAEventsBadgeScanner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}