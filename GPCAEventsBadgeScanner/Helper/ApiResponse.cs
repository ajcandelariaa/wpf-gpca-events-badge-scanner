using GPCAEventsBadgeScanner.Model;
using Newtonsoft.Json;

namespace GPCAEventsBadgeScanner.Helper
{
    public class ApiResponse
    {
        [JsonProperty("scannedAttendee")]
        public AttendeeModel ScannedAttendee { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
