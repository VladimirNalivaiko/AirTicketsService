using AirTicketsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicketsService.Services
{
    public static class FlightService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static string[] Mounth_RUS = { "января", "февраля", "марта", "апреля", "мая", "июня",
            "июля", "августа", "сентября", "октября", "ноября", "декабря" };

        public static int GetNumOfSeats(int flightID)
        {
            return db.SeatModels.Count(x => x.FlightID == flightID);
        }

        public static int GetNumOfFreeSeats(int flightID)
        {
            return db.SeatModels.Count(x => x.FlightID == flightID && x.isFree);
        }

        public static int GetNumOfBookedSeats(int flightID)
        {
            return db.SeatModels.Count(x => x.FlightID == flightID && !x.isFree);
        }

        public static List<FlightModel> GetFlights()
        {
            return db.FlightModels.ToList();
        }

        public static List<FlightViewModel> GetFlights(string departurePlace, string arrivalPlace, DateTime? departureDate)
        {
            List<FlightViewModel> list = new List<FlightViewModel>();
            foreach(var item in db.FlightModels)
            {
             if(item.DeparturePlace == departurePlace && item.ArrivalPlace == arrivalPlace
                    && new DateTime(item.DepartureDate.Year, item.DepartureDate.Month, item.DepartureDate.Day) 
                    == departureDate)
                {
                    list.Add(new FlightViewModel(item));
                }
            }
            return list;
        }

        public static string[] GetMounth()
        {
            return Mounth_RUS;
        }
    }
}