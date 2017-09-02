using AirTicketsService.Models;
using AirTicketsService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTicketsService.Controllers
{
    public class CityController : Controller
    {
        public ActionResult GetCities(string subString)
        {
            return Json(CityService.GetCitiesBySubstring(subString));
        }
    }
}