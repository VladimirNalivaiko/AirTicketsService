using System;
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
    public class TicketController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ticket
        public ActionResult Index()
        {
            return View(db.TicketModels.ToList());
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketModel = db.TicketModels.Find(id);
            if (ticketModel == null)
            {
                return HttpNotFound();
            }
            return View(ticketModel);
        }

        // GET: Ticket/Create
        public ActionResult Create(int directFlightID, int returnFlightID)
        {
            OrderViewModel order = new OrderViewModel();
            order.DirectFlightID = directFlightID;
            order.ReturnFlightID = returnFlightID;
            order.DirectFreeSeatList = SeatService.GetFreeSeatsList(directFlightID);
            order.ReturnFreeSeatList = SeatService.GetFreeSeatsList(returnFlightID);
            return View(order);
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
            "ID,DirectFlightID,ReturnFlightID,DirectSeatNumber,ReturnSeatNumber,Name,SurName,PassportNumber,PhoneNumber,Email")] OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                SeatService.UpdateSeatState(order.DirectSeatNumber, order.DirectFlightID);
                SeatService.UpdateSeatState(order.ReturnSeatNumber, order.ReturnFlightID);

                TicketModel directTicket = new TicketModel(order, order.DirectFlightID, order.DirectSeatNumber);
                TicketModel returnTicket = new TicketModel(order, order.ReturnFlightID, order.ReturnSeatNumber);

                db.TicketModels.Add(directTicket);
                db.TicketModels.Add(returnTicket);
                db.SaveChanges();
                return RedirectToAction("Index", "Flight");
            }

            return View(order);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketModel = db.TicketModels.Find(id);
            if (ticketModel == null)
            {
                return HttpNotFound();
            }
            return View(ticketModel);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlaneID,SeatID,UserID")] TicketModel ticketModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketModel);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModel ticketModel = db.TicketModels.Find(id);
            if (ticketModel == null)
            {
                return HttpNotFound();
            }
            return View(ticketModel);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketModel ticketModel = db.TicketModels.Find(id);
            db.TicketModels.Remove(ticketModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult GetTicketsToAdminJson()
        {
            List<TicketModel> ticketsList = TicketService.GetTicketsList();
            List<FlightModel> flightList = FlightService.GetFlights();
            List<TicketAdminViewModel> list = new List<TicketAdminViewModel>();
            foreach(var item in ticketsList)
            {
                TicketAdminViewModel model = new TicketAdminViewModel();

                model.ID = item.ID;
                model.ArrivalPlace = flightList.FirstOrDefault(x => x.ID == item.FlightID).ArrivalPlace;
                model.DeparturePlace = flightList.FirstOrDefault(x => x.ID == item.FlightID).DeparturePlace;
                model.DepartureDate = flightList.FirstOrDefault(x => x.ID == item.FlightID).DepartureDate;           
                model.Name = item.Name;
                model.SurName = item.SurName;
                model.PassportNumber = item.PassportNumber;
                model.PhoneNumber = item.PhoneNumber;
                model.Email = item.Email;
                model.SeatNumber = SeatService.GetSeatNumberByID(item.SeatID);

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
