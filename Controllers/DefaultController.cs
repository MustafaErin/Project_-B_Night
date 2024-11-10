using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__B_Night.Entities;
using Project__B_Night.Context;
using PagedList;
using PagedList.Mvc;
using System.Web.ModelBinding;
using System.Runtime.CompilerServices;

namespace Project__B_Night.Controllers
{
    public class DefaultController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialBanner()
        {
            var values = context.Destinations.ToList();
            return PartialView(values);
        }
       
        public PartialViewResult PartialCountry(int p=1)
        {
            var value = context.Destinations.ToList().ToPagedList(p,4);
            var value2 = value.Count;
            ViewBag.sayı=value2;
            return PartialView(value);
            
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        
        public ActionResult DestinationDetail(int id)
        {
            var values = context.Destinations.Find(id);
           
            return View(values);
        }

        public PartialViewResult PartialPopap()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialPopap(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return PartialView();
        }
        public ActionResult Payment()
        {
            return View();
        }
    }
   
}
