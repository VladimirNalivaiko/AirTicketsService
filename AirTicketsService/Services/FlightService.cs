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

        public static List<FlightModel> GetFlights(string departurePlace, string arrivalPlace, DateTime? departureDate)
        {
            return db.FlightModels.Where(x => x.DeparturePlace == departurePlace
            && x.ArrivalPlace == arrivalPlace
            && x.DepartureDate == departureDate).ToList();
        }
    }
}