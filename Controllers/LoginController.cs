using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__B_Night.Entities;
using Project__B_Night.Context;
using System.Web.Security;

namespace Project__B_Night.Controllers
{
    public class LoginController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            
           var values= context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password==admin.Password);
         if (values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName,false);
                Session["x"]=values.UserName;
                return RedirectToAction("inbox","Message", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
           FormsAuthentication.SignOut();
            return RedirectToAction("index","Default");
        }

    }
}