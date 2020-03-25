using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Linq;


using Newtonsoft.Json;

using WeatherModels;

namespace WeatherApiClient
{
    public partial class WeatherClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public WeatherClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }

        private async Task<TemperatureModel> GetAsync<T>(Uri requestUrl)
        {     
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var rawWeather = JsonConvert.DeserializeObject<TemperatureModel>(data);
            return rawWeather;           
        }       

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;      
            return endpoint;
        }        
    }
}
