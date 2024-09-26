using GPCAEventsBadgeScanner.ViewModel;
using System.Configuration;
using System.Windows;

namespace GPCAEventsBadgeScanner.View.UserControl
{
    public partial class InitialSetupView
    {
        private MainViewModel _mainViewModel;

        public InitialSetupView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string location = Tb_Location.Text;

            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Location is required!");
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Add("Location", location);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            _mainViewModel.CurrentLocation = "Location: " + location;
            _mainViewModel.NavigateToHomeView();
        }
    }
}
