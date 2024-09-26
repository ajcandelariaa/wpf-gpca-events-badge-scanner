using GPCAEventsBadgeScanner.Model;
using GPCAEventsBadgeScanner.ViewModel;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace GPCAEventsBadgeScanner.View.UserControl
{
    public partial class HomeView
    {
        private MainViewModel _mainViewModel; 
        private string _actualText = "";


        public HomeView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Tb_scanned_code.Focus();
        }

        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _mainViewModel.BackDropStatus = "Visible";
            _mainViewModel.LoadingProgressStatus = "Visible";

            if (e.Key == Key.Enter)
            {
                string scannedCode = Tb_scanned_code.Password;

                if (scannedCode != null && scannedCode.Length >= 4)
                {
                    string firstFourContent = scannedCode.Substring(0, 4);

                    if (firstFourContent != "gpca")
                    {
                        MessageBox.Show("Invalid QR Code. Please try again!");
                    }
                    else
                    {
                        string encrypTextTextContent = scannedCode.Substring(4, scannedCode.Length - 4);

                        try
                        {
                            string decryptedText = DecodeBase64String(encrypTextTextContent);
                            string[] arrayDecryptedText = decryptedText.Split(',');

                            if (arrayDecryptedText.Length >= 5 && arrayDecryptedText[0] == ConfigurationManager.AppSettings["ScanningCode"])
                            {
                                if (arrayDecryptedText[1] == ConfigurationManager.AppSettings["EventId"] && arrayDecryptedText[2] == ConfigurationManager.AppSettings["EventCategory"])
                                {
                                    string delegateId = arrayDecryptedText[3];
                                    string delegateType = arrayDecryptedText[4];
                                    string apiCode = ConfigurationManager.AppSettings["ApiCode"];
                                    string location = ConfigurationManager.AppSettings["Location"];

                                    _mainViewModel.AttendeeViewModel.ScannedAttendee(apiCode, delegateId, delegateType, location);

                                }
                                else
                                {
                                    MessageBox.Show("Invalid QR Code. Please try again!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid QR Code. Please try again!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Invalid QR Code. Please try again!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid QR Code. Please try again!");
                }

                _mainViewModel.LoadingProgressStatus = "Collapsed";
                _mainViewModel.BackDropStatus = "Collapsed";

                Tb_scanned_code.Clear();
                Tb_scanned_code.Focus();
                e.Handled = true;
            }
        }

        private static string DecodeBase64String(string base64EncodedString)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64EncodedString);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("QR Invalid" + ex);
                return null;
            }
        }
    }
}
