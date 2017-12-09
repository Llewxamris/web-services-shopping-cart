using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
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
    }
}