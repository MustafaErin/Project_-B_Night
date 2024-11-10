using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__B_Night.Entities;
using Project__B_Night.Context;

namespace Project__B_Night.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult inbox()
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.UserName == a).Select(y=>y.Email).FirstOrDefault();
            var values=context.Messages.Where(x=>x.ReceiverMail==email).ToList();
            return View(values);
        }
        
        public ActionResult SendBox()
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.SenderMail == email).ToList();
            return View(values);
           
        }
        public ActionResult SendMessage()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {

            var a = Session["x"];
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault();
            message.SenderMail = email;
            message.SendDate = DateTime.Now;
            message.İsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();
           
            return RedirectToAction("SendBox","Message","Admin");

        }
        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();

            return RedirectToAction("inbox", "Message", "Admin");
        }
        public ActionResult OpenMessage(int id)
        {
            var value=context.Messages.Find(id);
            value.İsRead=true;
            return View(value);
        }
        
    }
}