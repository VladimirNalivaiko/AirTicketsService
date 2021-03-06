﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirTicketsService.Models;
using AirTicketsService.Services;

namespace AirTicketsService.Controllers
{
    public class FlightController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FlightModels
        public ActionResult Index(FlightUserSearchViewModel flight)
        {
            if (String.IsNullOrEmpty(flight.DeparturePlace))
            {
                return View();
            }
            else
            {
                SearchFlightViewModel model = new SearchFlightViewModel();
                model.DirectFlight = FlightService.GetFlights(flight.DeparturePlace, flight.ArrivalPlace, flight.DepartureDate);
                model.ReturnFlight = FlightService.GetFlights(flight.ArrivalPlace, flight.DeparturePlace, flight.ArrivalDate);
                model.Mounth = FlightService.GetMounth();
                return View("SearchResult", model);
            }
        }

        // GET: FlightModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightModel flightModel = db.FlightModels.Find(id);
            if (flightModel == null)
            {
                return HttpNotFound();
            }
            return View(flightModel);
        }

        // GET: FlightModels/Create
        public ActionResult Create(string returnUrl = "")
        {
            DoubleFlightViewModel flight = new DoubleFlightViewModel();
            
            flight.ReturnUrl = returnUrl != "" ? returnUrl : "";

            return View(flight);
        }

        // POST: FlightModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoubleFlightViewModel flight)
        {
            if (ModelState.IsValid)
            {
                FlightModel directFlight = new FlightModel(flight, flight.DirectDepartureDate, 
                    flight.DirectDepartureTime, flight.DirectTimeOfFlight, flight.DirectPrice, flight.DirectNumOfSeats);
                FlightModel returnFlight = new FlightModel(flight, flight.ReturnDepartureDate, 
                    flight.ReturnDepartureTime, flight.ReturnTimeOfFlight, flight.ReturnPrice, flight.ReturnNumOfSeats);

                db.FlightModels.Add(directFlight);
                db.FlightModels.Add(returnFlight);
                db.SaveChanges();

                SeatService.AddSeats(directFlight);
                SeatService.AddSeats(returnFlight);

                db.SaveChanges();                
                return string.IsNullOrEmpty(flight.ReturnUrl) ? RedirectToAction("Index") :
                    RedirectToAction("", flight.ReturnUrl.Substring(1));
            }

            return View(flight);
        }

        // GET: FlightModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightViewModel flight = new FlightViewModel();
            FlightModel flightModel = db.FlightModels.Find(id);

            flight.ID = flightModel.ID;
            flight.ArrivalPlace = flightModel.ArrivalPlace;
            flight.DeparturePlace = flightModel.DeparturePlace;
            flight.DepartureDate = flightModel.DepartureDate;
            flight.TimeOfFlight = flightModel.TimeOfFlight;
            flight.Price = flightModel.Price;
            flight.NumOfSeats = flightModel.NumOfSeats;

            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: FlightModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = 
            "ID,PlaneID,DeparturePlace,ArrivalPlace,Price,DepartureDate,NumOfSeats,DepartureTime")] FlightViewModel flightModel)
        {
            if (ModelState.IsValid && flightModel.NumOfSeats >= FlightService.GetNumOfBookedSeats(flightModel.ID))
            {
                int freeseats = flightModel.NumOfSeats - FlightService.GetNumOfSeats(flightModel.ID);
                if (freeseats > 0)
                {
                    for(int i = 0; i < freeseats; i++)
                    {
                        SeatModel seat = new SeatModel();
                        seat.FlightID = flightModel.ID;
                        seat.SeatNumber = i + 1;
                        seat.isFree = true;
                        db.SeatModels.Add(seat);
                    }
                    db.SaveChanges();
                }

                FlightModel flight = new FlightModel();

                flight.ID = flightModel.ID;
                flight.ArrivalPlace = flightModel.ArrivalPlace;
                flight.DeparturePlace = flightModel.DeparturePlace;
                flight.DepartureDate = flightModel.DepartureDate;
                flight.TimeOfFlight = flightModel.TimeOfFlight;
                flight.Price = flightModel.Price;
                flight.NumOfSeats = flightModel.NumOfSeats;

                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flightModel);
        }

        // GET: FlightModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightModel flightModel = db.FlightModels.Find(id);
            if (flightModel == null)
            {
                return HttpNotFound();
            }
            return View(flightModel);
        }

        // POST: FlightModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightModel flightModel = db.FlightModels.Find(id);
            db.FlightModels.Remove(flightModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetFlightsToAdminJson()
        {
            var flightsList = FlightService.GetFlights();
            List<FlightAdminViewModel> list = new List<FlightAdminViewModel>();
            foreach (var item in flightsList)
            {
                FlightAdminViewModel model = new FlightAdminViewModel();
                model.ID = item.ID;
                model.DeparturePlace = item.DeparturePlace;
                model.ArrivalPlace = item.ArrivalPlace;
                model.Price = item.Price;
                model.DepartureDate = item.DepartureDate;
                model.NumOfFreeSeats = FlightService.GetNumOfFreeSeats(item.ID);
                list.Add(model);
            }
            return Json(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
