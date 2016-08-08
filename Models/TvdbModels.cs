using System.Collections.Generic;

namespace TVKetchup.Models.TVDB
{
    public class Auth
    {
        public string apikey { get; set; }
        public string username { get; set; }
        public string userkey { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public string Error { get; set; }
    }

    public class SeriesData
    {
        public Series Data { get; set; }
        public JSONErrors Errors { get; set; }
    }

    public class Series
    {
        public int? id { get; set; }
        public string seriesName { get; set; }
        public List<string> aliases { get; set; }
        public string banner { get; set; }
        public int? seriesId { get; set; }
        public string status { get; set; }
        public string firstAired { get; set; }
        public string network { get; set; }
        public string networkId { get; set; }
        public string runtime { get; set; }
        public List<string> genre { get; set; }
        public string overview { get; set; }
        public int? lastUpdated { get; set; }
        public string airsDayOfWeek { get; set; }
        public string airsTime { get; set; }
        public string rating { get; set; }
        public string imdbId { get; set; }
        public string zap2itId { get; set; }
        public string added { get; set; }
        public double? siteRating { get; set; }
        public int siteRatingCount { get; set; }
    }

    public class SeriesEpisodes
    {
        public Links links { get; set; }
        public List<BasicEpisode> data { get; set; }
        public JSONErrors errors { get; set; }

        public SeriesEpisodes()
        {
            links = new Links();
            data = new List<BasicEpisode>();
            errors = new JSONErrors();
        }

        public void Merge(SeriesEpisodes other)
        {
            links = other.links;
            data.AddRange(other.data);
            errors.invalidFilters.AddRange(other.errors.invalidFilters);
            errors.invalidQueryParams.AddRange(other.errors.invalidQueryParams);
        }
    }

    public class Links
    {
        public int? first { get; set; }
        public int? last { get; set; }
        public int? next { get; set; }
        public int? previous { get; set; }
    }

    public class BasicEpisode
    {
        public int? absoluteNumber { get; set; }
        public int? airedEpisodeNumber { get; set; }
        public int? airedSeason { get; set; }
        public string dvdEpisodeNumber { get; set; }
        public int? dvdSeason { get; set; }
        public string episodeName { get; set; }
        public int? id { get; set; }
        public string overview { get; set; }
    }

    public class EpisodeRecordData {
        public Episode data { get;set; }
        public JSONErrors errors { get;set; }
    }

    public class Episode {
        public int? id { get;set; }
        public int? airedSeason { get;set; }
        public int? airedEpisodeNumber { get;set; }
        public string episodeName { get;set; }
        public string firstAired { get;set; }
        public List<string> guestStars { get;set; }
        public string director { get;set; }
        public List<string> directors { get;set; }
        public List<string> writers { get;set; }
        public string overview { get;set; }
        public string productionCode { get;set; }
        public string showUrl { get;set; }
        public int? lastUpdated { get;set; }
        public string dvdDiscid { get;set; }
        public int? dvdSeason { get;set; }
        public double? dvdEpisodeNumber { get;set; }
        public double? dvdChapter { get;set; }
        public int? absoluteNumber { get;set; }
        public string filename { get;set; }
        public string seriesId { get;set; }
        public string lastUpdatedBy { get;set; }
        public int? airsAfterSeason { get;set; }
        public int? airsBeforeSeason { get;set; }
        public int? airsBeforeEpisode{ get;set; }
        public int? thumbAuthor { get;set; }
        public string thumbAdded { get;set; }
        public string thumbWidth { get;set; }
        public string thumbHeight { get;set; }
        public string imdbId { get;set; }
        public double? siteRating { get;set; }
        public int? siteRatingCount { get;set; }
    }

    public class JSONErrors
    {
        public List<string> invalidFilters { get; set; }
        public string invalidLanguage { get; set; }
        public List<string> invalidQueryParams { get; set; } 

        public JSONErrors()
        {
            invalidFilters = new List<string>();
            invalidQueryParams = new List<string>();
        }
    }

    public class SeriesImageQueryResults {
        public List<SeriesImageQueryResult> data { get; set; }
        public JSONErrors errors { get; set; }
    }

    public class SeriesImageQueryResult {
        public int? id { get; set; }
        public string keyType { get; set; }
        public string subKey { get; set; }
        public string fileName { get; set; }
        public int? languageId { get; set; }
        public string resolution { get; set; }
        public inline_model ratingsInfo { get; set; }
        public string thumbnail { get; set; }
    }

    public class inline_model {
        public double? average { get; set; }
        public int? count { get; set; }
    }
}