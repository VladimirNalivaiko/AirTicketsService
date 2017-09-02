using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirTicketsService.Models;

namespace AirTicketsService.Controllers
{
    public class SeatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Seat
        public ActionResult Index()
        {
            return View(db.SeatModels.ToList());
        }

        // GET: Seat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatModel seatModel = db.SeatModels.Find(id);
            if (seatModel == null)
            {
                return HttpNotFound();
            }
            return View(seatModel);
        }

        // GET: Seat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlaneID")] SeatModel seatModel)
        {
            if (ModelState.IsValid)
            {
                db.SeatModels.Add(seatModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seatModel);
        }

        // GET: Seat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatModel seatModel = db.SeatModels.Find(id);
            if (seatModel == null)
            {
                return HttpNotFound();
            }
            return View(seatModel);
        }

        // POST: Seat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlaneID")] SeatModel seatModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seatModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seatModel);
        }

        // GET: Seat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatModel seatModel = db.SeatModels.Find(id);
            if (seatModel == null)
            {
                return HttpNotFound();
            }
            return View(seatModel);
        }

        // POST: Seat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeatModel seatModel = db.SeatModels.Find(id);
            db.SeatModels.Remove(seatModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
