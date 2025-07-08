using Newtonsoft.Json;

namespace WHISTB.Model
{
    public class Season
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Season")]
        public string SeasonNumber { get; set; }

        [JsonProperty("totalSeasons")]
        public string TotalSeasons { get; set; }

        [JsonProperty("Episodes")]
        public List<SeasonEpisode> Episodes { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}