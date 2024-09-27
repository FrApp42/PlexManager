namespace PlexManager.Model
{
    public class AboutGroup
    {
        public string Name { get; set; } = string.Empty;
        public List<AboutItem> Items { get; set; } = new List<AboutItem>();
    }
}
