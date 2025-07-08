using Newtonsoft.Json;

namespace WHISTB.Model
{
    public class SearchList
    {
        [JsonProperty("Search")]
        public List<SearchItem> SearchResults { get; set; }

        [JsonProperty("totalResults")]
        public string TotalResults { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}