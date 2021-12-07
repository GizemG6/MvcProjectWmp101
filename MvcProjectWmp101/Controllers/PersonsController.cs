using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult NewPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPerson(Persons persons)
        {
            DatabaseContext db = new DatabaseContext();
            db.Persons.Add(persons);

            int result = db.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Person enrollment completed successfully.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Person enrollment failure.";
                ViewBag.Status = "danger";
            }
            ModelState.Clear();
            return View();
        }
    }
}