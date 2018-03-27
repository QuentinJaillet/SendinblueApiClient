using System.Collections.Generic;
using Newtonsoft.Json;

namespace SendinblueApiClient
{
    public partial class SendinblueClient
    {
        public class Templates
        {
            public int Count { get; set; }

            [JsonProperty("templates")]
            public List<Template> TemplatesList { get; set; }
        }
    }
}
