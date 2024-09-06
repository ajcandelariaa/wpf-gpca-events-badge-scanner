using GPCAEventsBadgeScanner.Helper;
using GPCAEventsBadgeScanner.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace GPCAEventsBadgeScanner.ViewModel
{
    public class AttendeeViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        private MainViewModel _mainViewModel;

        public AttendeeViewModel(MainViewModel mainViewModel)
        {
            _httpClient = new HttpClient();
            _mainViewModel = mainViewModel;
        }

        public async Task ScannedAttendee(string code, string delegateId, string delegateType)
        {
            try
            {
                var passData = new Dictionary<string, string>
                {
                    {"code", code},
                    {"delegateId", delegateId.ToString()},
                    {"delegateType", delegateType},
                };

                    var jsonData = JsonConvert.SerializeObject(passData);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(EventModel.APIEndpoint + "/badge-scan", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var formattedResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                    _mainViewModel.CurrentAttendee = formattedResponse?.ScannedAttendee;
                }
                else
                {
                    _mainViewModel.LoadingProgressStatus = "Collapsed";
                    MessageBox.Show($"Server error. Status code: {response.StatusCode}");
                }
                
            }
            catch (Exception ex)
            {
                _mainViewModel.LoadingProgressStatus = "Collapsed";
                MessageBox.Show($"Error scanning badge: {ex.Message}");
            }
        }

    }
}
