using Newtonsoft.Json;

namespace SendinblueApiClient
{
    public class CreateContactModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("listIds")]
        public int[] listIds { get; set; }

        [JsonProperty("emailBlacklisted")]
        public bool EmailBlacklisted { get; set; }

        [JsonProperty("smsBlacklisted")]
        public bool SmsBlacklisted { get; set; }

        [JsonProperty("updateEnabled")]
        public bool UpdateEnabled { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }
}
