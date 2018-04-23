using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SendinblueApiClient
{

    public class ContactResponse
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("emailBlacklisted")]
        public bool EmailBlacklisted { get; set; }

        [JsonProperty("smsBlacklisted")]
        public bool SmsBlacklisted { get; set; }

        [JsonProperty("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("listIds")]
        public List<int> ListIds { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ContactsResponse
    {
        [JsonProperty("contacts")]
        public List<ContactResponse> Contacts { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
