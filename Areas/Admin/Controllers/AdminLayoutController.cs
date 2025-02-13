﻿using Microsoft.Ajax.Utilities;
using Project__B_Night.Context;
using Project__B_Night.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project__B_Night.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
      TravelContext context=new TravelContext();
        Class1 cs=new Class1();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            var username = Session["x"];
            var email = context.Admins
                .Where(x => x.UserName == username)
                .Select(y => y.Email)
                .FirstOrDefault();

            // Mesajları al
            var messages = context.Messages
                .Where(x => x.ReceiverMail == email)
                .ToList();

            if (messages != null && messages.Any())
            {
                ViewBag.girisYapanKullaniciResim = context.Admins
                    .Where(x => x.UserName == username)
                    .Select(y => y.Image)
                    .FirstOrDefault();

                ViewBag.girisYapanKullaniciAd = context.Admins
                    .Where(x => x.UserName == username)
                    .Select(y => y.Name)
                    .FirstOrDefault();

                ViewBag.girisYapanKullaniciMail = context.Admins
                    .Where(x => x.UserName == username)
                    .Select(y => y.Email)
                    .FirstOrDefault();

                // Class1 nesnesi oluştur
                Class1 cs = new Class1();
                cs.Deger1 = context.Destinations.ToList();
                cs.Deger2 = messages;
                return PartialView(cs);
            }
            return PartialView(new Class1());
        }

    }
}

