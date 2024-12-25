using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    public class LibraryMovieVideo
    {
        [XmlAttribute("ratingKey")]
        public int RatingKey { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("guid")]
        public string Guid { get; set; }

        [XmlAttribute("slug")]
        public string Slug { get; set; }

        [XmlAttribute("studio")]
        public string Studio { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("titleSort")]
        public string TitleSort { get; set; }

        [XmlAttribute("originalTitle")]
        public string OriginalTitle { get; set; }

        [XmlAttribute("contentRating")]
        public string ContentRating { get; set; }

        [XmlAttribute("summary")]
        public string Summary { get; set; }

        [XmlAttribute("rating")]
        public double Rating { get; set; }

        [XmlAttribute("audienceRating")]
        public double AudienceRating { get; set; }

        [XmlAttribute("year")]
        public int Year { get; set; }

        [XmlAttribute("thumb")]
        public string Thumb { get; set; }

        [XmlAttribute("art")]
        public string Art { get; set; }

        [XmlAttribute("duration")]
        public long Duration { get; set; }

        [XmlAttribute("originallyAvailableAt")]
        public DateTime OriginallyAvailableAt { get; set; }

        [XmlAttribute("addedAt")]
        public long AddedAt { get; set; }

        [XmlAttribute("updatedAt")]
        public long UpdatedAt { get; set; }

        [XmlAttribute("audienceRatingImage")]
        public string AudienceRatingImage { get; set; }

        [XmlAttribute("chapterSource")]
        public string ChapterSource { get; set; }

        [XmlAttribute("hasPremiumPrimaryExtra")]
        public int HasPremiumPrimaryExtra { get; set; }

        [XmlAttribute("ratingImage")]
        public string RatingImage { get; set; }

        [XmlElement("Media")]
        public LibraryMovieVideoMedia Media { get; set; }

        [XmlElement("Image")]
        public List<LibraryImage> Images { get; set; }

        [XmlElement("UltraBlurColors")]
        public UltraBlurColors UltraBlurColors { get; set; }

        [XmlElement("Genre")]
        public List<Genre> Genres { get; set; }

        [XmlElement("Country")]
        public List<Country> Countries { get; set; }

        [XmlElement("Director")]
        public List<LibraryMovieVideoDirector> Directors { get; set; }

        [XmlElement("Writer")]
        public List<LibraryMovieVideoWriter> Writers { get; set; }

        [XmlElement("Role")]
        public List<Role> Roles { get; set; }

        [XmlIgnore]
        public Uri ThumbUrl { get; set; }
    }
}
