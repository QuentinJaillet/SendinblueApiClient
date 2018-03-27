using System.Collections.Generic;

namespace SendinblueApiClient.Models
{
    public class Account
    {
        public List<Plan> Plan { get; set; }
        public Relay Relay { get; set; }
        public MarketingAutomation MarketingAutomation { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public Address Address { get; set; }
    }
}