﻿using Project__B_Night.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project__B_Night.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            List<int> capacity = context.Destinations.Take(3).Select(x => x.Capacity).ToList();
            ViewBag.Capacity = capacity;

            List<decimal> price = context.Destinations.Take(3).Select(x => x.Price).ToList();
            ViewBag.Price = price;

            List<int> daynight = context.Destinations.Take(3).Select(x => x.DayNight).ToList();
            ViewBag.DayNight = daynight;

            var values = context.Destinations.ToList();
            return View(values);
        }
    }
}