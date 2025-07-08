using Newtonsoft.Json;

namespace WHISTB.Model
{
    public class SeasonEpisode
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Released")]
        public string Released { get; set; }

        [JsonProperty("Episode")]
        public string Episode { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }
    }
}