using System.Net.Http.Headers;
using Newtonsoft.Json;
using WHISTB.Model;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace WHISTB.Client
{
    public class OmdbClient
    {
        private const string BaseUrl = "http://www.omdbapi.com/?";
        private readonly string _apikey = Key.ApiKey;
        private readonly bool _rottenTomatoesRatings = false;

        public Item GetItemByTitle(string title, OmdbType type, int? year, bool fullPlot = false)
        {
            var query = QueryBuilder.GetItemByTitleQuery(title, type, year, fullPlot);

            var item = GetOmdbDataAsync<Item>(query).Result;

            if (item.Response.Equals("False"))
            {
                throw new HttpRequestException(item.Error);
            }

            return item;
        }

        private async Task<T> GetOmdbDataAsync<T>(string query)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(BaseUrl) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client
                    .GetAsync($"{BaseUrl}apikey={_apikey}{query}&tomatoes={_rottenTomatoesRatings}")
                    .ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    return default(T);
                }

                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    DateParseHandling = DateParseHandling.None,
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        var currentError = args.ErrorContext.Error.Message;
                        args.ErrorContext.Handled = true;
                    }
                });
            }
        }
    }
}