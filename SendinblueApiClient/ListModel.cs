namespace SendinblueApiClient
{
    public class ListModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalSubscribers { get; set; }
        public int totalBlacklisted { get; set; }
        public int folderId { get; set; }
    }
}
