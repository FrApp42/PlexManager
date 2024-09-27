using System.Text.Json.Serialization;

namespace PlexAPI.Models.Account
{
    public class Subscriptions
    {
        [JsonPropertyName("id")]
        public object Id { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("renewsAt")]
        public DateTime? RenewsAt { get; set; }

        [JsonPropertyName("endsAt")]
        public DateTime? EndsAt { get; set; }

        //[JsonPropertyName("billing")]
        //public Billing Billing { get; set; }

        [JsonPropertyName("canceled")]
        public bool Canceled { get; set; }

        [JsonPropertyName("gracePeriod")]
        public bool GracePeriod { get; set; }

        [JsonPropertyName("onHold")]
        public bool OnHold { get; set; }

        [JsonPropertyName("canReactivate")]
        public bool CanReactivate { get; set; }

        [JsonPropertyName("canUpgrade")]
        public bool CanUpgrade { get; set; }

        [JsonPropertyName("canDowngrade")]
        public bool CanDowngrade { get; set; }

        [JsonPropertyName("canConvert")]
        public bool CanConvert { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("transfer")]
        public bool Transfer { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonIgnore]

        public bool IsActive { get 
            {
                return (State.ToLower() == "active");
            }
        }
    }
}
