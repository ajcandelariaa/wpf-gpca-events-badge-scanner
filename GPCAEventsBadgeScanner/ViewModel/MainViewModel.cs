using GPCAEventsBadgeScanner.Model;
using GPCAEventsBadgeScanner.View.UserControl;
using System.Windows.Controls;

namespace GPCAEventsBadgeScanner.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private AttendeeViewModel _attendeeViewModel;
        private AttendeeModel _currentAttendee;
        private string _backDropStatus = "Collapsed";
        private string _loadingProgressStatus = "Collapsed";
        private UserControl _currentView;

        public string EventBanner 
        {
            get
            {
                return EventModel.EventBanner;
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

        public MainViewModel()
        {
            AttendeeViewModel = new AttendeeViewModel(this);
            CurrentView = new HomeView(this);
        }
    }
}
