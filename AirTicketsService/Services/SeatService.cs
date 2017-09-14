using AirTicketsService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTicketsService.Services
{
    public static class SeatService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static List<SeatModel> GetSeatsList()
        {
            return db.SeatModels.ToList();
        }

        public static List<SelectListItem> GetFreeSeatsList(int flightID)
        {
            List<SelectListItem> returnList = new List<SelectListItem>();
            foreach (var item in db.SeatModels)
            {
                if (item.isFree && item.FlightID == flightID)
                {
                    SelectListItem selectItem = new SelectListItem();
                    selectItem.Value = item.SeatNumber.ToString();
                    selectItem.Text = item.SeatNumber.ToString();
                    returnList.Add(selectItem);
                }
            }
            return returnList;
        }

        public static SeatModel GetSeatByNumber(int seatNumber)
        {
            return db.SeatModels.FirstOrDefault(x => x.SeatNumber == seatNumber);
        }

        public static SeatModel GetSeatByNumberAndFlightID(int seatNumber, int flightID)
        {
            return db.SeatModels.Where(x => x.FlightID == flightID).FirstOrDefault(x => x.SeatNumber == seatNumber);
        }

        public static int GetSeatNumberByID(int id)
        {
            return db.SeatModels.Find(id).SeatNumber;
        }

        public static void UpdateSeatState(int seatNumber, int flightID)
        {
            SeatModel seat = GetSeatByNumberAndFlightID(seatNumber, flightID);
            seat.isFree = !seat.isFree;
            db.Entry(seat).State = EntityState.Modified;
            db.SaveChanges();
            return;
        }        
        
        public static void DeleteSeat(SeatModel seat)
        {
            db.Entry(seat).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void AddSeats(FlightModel flight)
        {
            for (int i = 0; i < flight.NumOfSeats; i++)
            {
                SeatModel seat = new SeatModel();
                seat.FlightID = flight.ID;
                seat.SeatNumber = i;
                seat.isFree = true;
                db.SeatModels.Add(seat);
            }
        }
    }
}