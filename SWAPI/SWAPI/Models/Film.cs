using Newtonsoft.Json;

namespace SWAPI.Models
{
    public class Film
    {
        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        [JsonProperty("opening_crawl")]
        public string Description { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
    }
}