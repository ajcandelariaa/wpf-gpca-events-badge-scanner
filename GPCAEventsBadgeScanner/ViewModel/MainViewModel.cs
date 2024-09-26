using GPCAEventsBadgeScanner.Model;
using GPCAEventsBadgeScanner.View.UserControl;
using System.Configuration;
using System.Windows.Controls;

namespace GPCAEventsBadgeScanner.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private AttendeeViewModel _attendeeViewModel;
        private AttendeeModel _currentAttendee;
        private string _backDropStatus = "Collapsed";
        private string _loadingProgressStatus = "Collapsed";
        private string _currentLocation;
        private UserControl _currentView;

        public string EventBanner 
        {
            get
            {
                return EventModel.EventBanner;
            }
        }

        public string CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public string LoadingProgressStatus
        {
            get { return _loadingProgressStatus; }
            set
            {
                _loadingProgressStatus = value;
                OnPropertyChanged(nameof(LoadingProgressStatus));
            }
        }

        public string BackDropStatus
        {
            get { return _backDropStatus; }
            set
            {
                _backDropStatus = value;
                OnPropertyChanged(nameof(BackDropStatus));
            }
        }

        public AttendeeViewModel AttendeeViewModel
        {
            get { return _attendeeViewModel; }
            set
            {
                if (_attendeeViewModel != value)
                {
                    _attendeeViewModel = value;
                    OnPropertyChanged(nameof(AttendeeViewModel));
                }
            }
        }

        public AttendeeModel CurrentAttendee
        {
            get { return _currentAttendee; }
            set
            {
                _currentAttendee = value;
                OnPropertyChanged(nameof(CurrentAttendee));
            }
        }

        public UserControl CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public void NavigateToHomeView()
        {
            CurrentView = new HomeView(this);
        }

        public MainViewModel()
        {
            AttendeeViewModel = new AttendeeViewModel(this);

            string location = ConfigurationManager.AppSettings["Location"];

            if (string.IsNullOrEmpty(location))
            {
                CurrentView = new InitialSetupView(this);
            } else
            {
                CurrentView = new HomeView(this);
                CurrentLocation = "Location: " + location;
            }
        }
    }
}
