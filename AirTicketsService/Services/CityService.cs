using AirTicketsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicketsService.Services
{
    public static class CityService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static List<CityModel> GetCitiesBySubstring(string subString)
        {
            return db.CityModels.Where(x => x.Name.ToUpper().StartsWith(subString.ToUpper())).ToList();
        }
    }
}