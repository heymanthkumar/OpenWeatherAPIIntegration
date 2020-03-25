using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSUS.Models;
using NSUS.Factory;
using NSUS.Utilities;
using WeatherModels;
using System.Net.Http;

namespace NSUS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ConfigurationsModel> appSettings;

        public HomeController(IOptions<ConfigurationsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Weather()
        {
            
            try
            {
                string city = Request.Form["txtCity"];
                TemperatureModel model = await WeatherClientFactory.Instance.GetTemperature(city);               
                return View(model);
            }
            catch (HttpRequestException httpRequestException)
            {
                //return View("../Home/Index", null);              
                return BadRequest($"Error getting weather from OpenWeather, Please go back and enter different city name : {httpRequestException.Message}");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
