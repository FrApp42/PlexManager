using System.Text.Json.Serialization;

namespace PlexAPI.Models.Account
{
    public class Service
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
