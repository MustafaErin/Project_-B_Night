using Project__B_Night.Context;
using Project__B_Night.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project__B_Night.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }
        public ActionResult DeleteReservation(int id)
        {
            var values = context.Reservations.Find(id);
            context.Reservations.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");

        }
        public ActionResult CreateReservation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
           
        }
        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var values=context.Reservations.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateReservation(Reservation reservation)
        {
            var values = context.Reservations.Find(reservation.ReservationId);
            values.Name = reservation.Name;
            values.ReservationDate = reservation.ReservationDate;
            values.Description = reservation.Description;
            values.Payment = reservation.Payment;
            values.Phone = reservation.Phone;
            values.PersonCount = reservation.PersonCount;
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }

      

    }
}