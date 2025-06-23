namespace PlexManager.Models
{
    public class Media
    {
        public string Title { get; set; }
        public Uri ThumbUrl { get; set; }
        public int Year { get; set; }
        public long Duration { get; set; }
        public double Rating { get; set; }
        public string Summary { get; set; }
        public string MediaType { get; set; }
        public string Key { get; set; }
        public int? Season { get; set; }
    }
}
