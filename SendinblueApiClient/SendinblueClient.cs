using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SendinblueApiClient.Models;

namespace SendinblueApiClient
{
    public class SendinblueClient
    {
        private const string ApiUrl = "https://api.sendinblue.com/v3/";
        private readonly string _apiKey;

        public SendinblueClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Lists GetLists()
        {
            var client = new RestClient("https://api.sendinblue.com/v3/contacts/lists");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("api-key", _apiKey);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Lists>(response.Content);
        }

        public void CreateContact(CreateContactModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var client = new RestClient("https://api.sendinblue.com/v3/contacts");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("api-key", _apiKey);
            request.AddParameter("undefined", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
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

    public class ListModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalSubscribers { get; set; }
        public int totalBlacklisted { get; set; }
        public int folderId { get; set; }
    }

    public class Lists
    {
        public List<ListModel> lists { get; set; }
        public int count { get; set; }
    }

}
