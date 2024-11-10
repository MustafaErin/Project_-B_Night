using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using Project__B_Night.Context;
using Project__B_Night.Entities;

namespace Project__B_Night.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            var username = Session["x"];
            var values=context.Admins.Where(x=>x.UserName== username).FirstOrDefault();
            return View(values);
        }
       
    }
}