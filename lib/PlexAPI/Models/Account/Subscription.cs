using System.Text.Json.Serialization;

namespace PlexAPI.Models.Account
{
    public class Subscription
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("subscribedAt")]
        public DateTime SubscribedAt { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public bool IsActive
        {
            get
            {
                return (Status.ToLower() == "active");
            }
        }

        [JsonPropertyName("paymentService")]
        public string PaymentService { get; set; }

        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("features")]
        public List<string> Features { get; set; }
    }
}
