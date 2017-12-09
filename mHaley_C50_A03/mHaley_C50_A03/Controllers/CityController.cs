using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using mHaley_C50_A03.CitiesService;

namespace mHaley_C50_A03.Controllers
{
    public class CityController : Controller
    {
        private readonly CitiesSoapClient _citiesSoap = new CitiesSoapClient();
        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCities(string countryCode)
        {
            CityDetail[] cities = _citiesSoap.GetCities(countryCode, "10");
            Dictionary<string, string> citiesDictionary = cities.ToDictionary(cityDetail => cityDetail._id.ToString(), cityDetail => cityDetail.name);
            return Json(citiesDictionary, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCityDetails(string cityCode)
        {
            CityDetail cityLocation = _citiesSoap.GetCityDetail(int.Parse(cityCode));
            XElement cityWeatherXElement = _citiesSoap.GetCityWeather(int.Parse(cityCode));

            IEnumerable<string> cityWeatherValue = cityWeatherXElement.Elements("temperature")
                .Select(i => i.Attribute("value").Value);

            IEnumerable<string> cityWeatherMetric = cityWeatherXElement.Elements("temperature")
                .Select(i => i.Attribute("unit").Value);

            char cityWeatherMetricChar = cityWeatherMetric.ElementAt(0) == "metric" ? 'C' : 'F';
            string cityTemperature = cityWeatherValue.ElementAt(0) + " " + cityWeatherMetricChar;


            // Theres more weather data available, but it would just be several
            // repeats of the above selectors.
            return Json(new List<string>
            {
                cityLocation.coord.lat.ToString(),
                cityLocation.coord.lon.ToString(),
                cityTemperature
            }, JsonRequestBehavior.AllowGet);
        }
    }
}