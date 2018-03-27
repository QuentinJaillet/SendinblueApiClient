using System;
using Newtonsoft.Json;
using RestSharp;
using SendinblueApiClient.Models;

namespace SendinblueApiClient
{
    public partial class SendinblueClient
    {
        private const string ApiUrl = "https://api.sendinblue.com/v3/";
        private readonly string _apiKey;

        public SendinblueClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Account GetAccount()
        {
            var response = GetRestRequest("account");
            return JsonConvert.DeserializeObject<Account>(response.Content);
        }

        public Templates GetTemplates()
        {
            var response = GetRestRequest("smtp/templates");
            return JsonConvert.DeserializeObject<Templates>(response.Content);
        }

        public void SendTemplate(int templateId, string emailTo)
        {
            var client = new RestClient(string.Format("https://api.sendinblue.com/v3/smtp/templates/{0}/send", templateId));
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("api-key", _apiKey);

            request.AddParameter("undefined", "{\"emailTo\":[\"" + emailTo + "\"]}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
        }

        private IRestResponse GetRestRequest(string url)
        {
            var client = new RestClient(string.Concat(ApiUrl, url));
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("api-key", _apiKey);
            return client.Execute(request);
        }

        public class Sender
        {
            public string name { get; set; }
            public string email { get; set; }
        }

        public class Template
        {
            public int Id { get; set; }
            public string name { get; set; }
            public string subject { get; set; }
            public bool isActive { get; set; }
            public bool testSent { get; set; }
            public Sender sender { get; set; }
            public string replyTo { get; set; }
            public string toField { get; set; }
            public string tag { get; set; }
            public string htmlContent { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime modifiedAt { get; set; }
        }
    }
}
