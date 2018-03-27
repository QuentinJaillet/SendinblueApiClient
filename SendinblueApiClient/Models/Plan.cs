namespace SendinblueApiClient.Models
{
    public class Plan
    {
        public string Type { get; set; }
        public double Credits { get; set; }
        public string CreditsType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}