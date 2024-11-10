using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project__B_Night.Context;
using Project__B_Night.Entities;

namespace Project__B_Night.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
       TravelContext context=new TravelContext();
        [Authorize]
        public ActionResult CategoryList()
        {
            var value = context.Categories.ToList();
            return View(value);
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            value.CategoryStatus = category.CategoryStatus;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");

        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            var value=context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList","Category","Admin" );
        }
    }
}

