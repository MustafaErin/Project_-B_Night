using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__B_Night.Entities;
using Project__B_Night.Context;

namespace Project__B_Night.Areas.Admin.Controllers
{
    [Authorize]
    public class DestinationController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult DestinationList()
        {
            var values=context.Destinations.ToList();
            return View(values);
        }
        public ActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDestination(Destination destination)
        {
            context.Destinations.Add(destination);
            context.SaveChanges();
            return RedirectToAction("DestinationList","Destination","Admin");

        }
        public ActionResult DeleteDestination(int id)
        {
            var values = context.Destinations.Find(id);
            context.Destinations.Remove(values);
            context.SaveChanges();

            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateDestination(int id)
        {
            var values = context.Destinations.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateDestination(Destination destination)
        {
            var values = context.Destinations.Find(destination.DestinationId);
            values.Country=destination.Country;
            values.Title=destination.Title;
            values.City=destination.City;
            values.Description=destination.Description;
            values.DayNight=destination.DayNight;
            values.Price=destination.Price;
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
    }
}