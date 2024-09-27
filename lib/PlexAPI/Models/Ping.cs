using System.Text.Json.Serialization;

namespace PlexAPI.Models
{
    internal class Ping
    {

        [JsonPropertyName("pong")]
        public bool Pong { get; set; }
    }
}
