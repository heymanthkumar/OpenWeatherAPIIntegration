using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using WeatherModels;

namespace WeatherApiClient
{
    public partial class WeatherClient
    {
        public async Task<TemperatureModel> GetTemperature(string city)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"/data/2.5/weather?q={city}&units=metric&appid=d464dfc079a8d334b7c39446eb010492"));
            return await GetAsync<TemperatureModel>(requestUrl);
        }      
    }
}
