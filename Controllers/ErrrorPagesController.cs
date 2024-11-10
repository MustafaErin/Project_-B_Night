using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project__B_Night.Controllers
{
    public class ErrrorPagesController : Controller
    {
        // GET: ErrrorPages
        public ActionResult Page404()
        {
            return View();
        }
    }
}