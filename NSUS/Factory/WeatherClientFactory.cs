using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

using NSUS.Utilities;
using WeatherApiClient;

namespace NSUS.Factory
{  
    internal static class WeatherClientFactory
    {     
        public static Uri ApiUri { get; set; }

        private static Lazy<WeatherClient> restClient = new Lazy<WeatherClient>(
          () => new WeatherClient(ApiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);

        static WeatherClientFactory()
        {
            ApiUri = new Uri(ApplicationSettings.WebApiUrl);
        }

        public static WeatherClient Instance => restClient.Value;       
    }
}
