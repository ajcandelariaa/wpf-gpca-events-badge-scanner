using System.Configuration;

namespace GPCAEventsBadgeScanner.Model
{
    public class EventModel
    {
        public static string EventCategory = ConfigurationManager.AppSettings["EventCategory"];
        public static string EventYear = ConfigurationManager.AppSettings["EventYear"];
        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        public static string EventBanner = "/GPCAEventsBadgeScanner;component/Assets/Images/Banners/img_2024_anc.jpg";
        public static string APIEndpoint { get; set; }

        static EventModel()
        {
            APIEndpoint = $"{ApiUrl}{EventCategory}/{EventYear}";
        }
    }
}
