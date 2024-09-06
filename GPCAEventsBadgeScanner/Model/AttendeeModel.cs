using Newtonsoft.Json;

namespace GPCAEventsBadgeScanner.Model
{
    public class AttendeeModel
    {
        [JsonProperty("accessType")]
        public string AccessType { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("badgeType")]
        public string BadgeType { get; set; }
    }

}
