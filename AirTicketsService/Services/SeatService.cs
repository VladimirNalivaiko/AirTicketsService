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

        public static int GetSeatIDByNumber(int seatNumber)
        {
            return db.SeatModels.FirstOrDefault(x => x.SeatNumber == seatNumber).ID;
        }

        public static int GetSeatNumberByID(int id)
        {
            return db.SeatModels.Find(id).SeatNumber;
        }

        public static void UpdateSeatState(int seatNumber)
        {
            SeatModel seat = GetSeatByNumber(seatNumber);
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
    }
}