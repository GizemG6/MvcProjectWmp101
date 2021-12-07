using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class ClassesController : Controller
    {
        public ActionResult NewClasses()
        {
            studentDatabaseContext db = new studentDatabaseContext();

            List<SelectListItem> classesList = (from s in db.Classes.ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = s.Name,
                                                     Value = s.Id.ToString()
                                                 }).ToList();

            TempData["classes"] = classesList;
            ViewBag.students = classesList;
            return View();
        }
        [HttpPost]
        public ActionResult NewClasses(Classes classes)
        {

            studentDatabaseContext db = new studentDatabaseContext();
            db.Classes.Add(classes);

            int result = db.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Class enrollment completed successfully.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Class enrollment failure.";
                ViewBag.Status = "danger";
            }
            ModelState.Clear();
            return View();
        }
    }
}