using System;

namespace SendinblueApiClient
{
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
