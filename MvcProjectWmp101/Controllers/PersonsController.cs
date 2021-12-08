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

        public ActionResult Update(int? pid)//null gelebilir
        {
            Persons per = null;//else durumu olmaması icin
            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                per = db.Persons.FirstOrDefault(x => x.Id == pid);
            }
            return View(per);
        }
        [HttpPost,ActionName("Update")]
        public ActionResult Update(Persons model,int? pid)
        {
            DatabaseContext db = new DatabaseContext();
            Persons persons = db.Persons.FirstOrDefault(x => x.Id == pid);
            if (persons != null)
            {
                persons.Name = model.Name;
                persons.SurName = model.SurName;
                persons.Age = model.Age;

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
            }
            return View();
        }
        public ActionResult Delete(int? pid)
        {
            Persons per = null;
            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                per = db.Persons.Find(pid);
            }
            return View(per);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOk(int? pid)
        {
            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Persons per = db.Persons.Find(pid);
                List<Addresses> adr = (from s in db.Addresses where s.Persons.Id == pid select s).ToList();
                db.Addresses.RemoveRange(adr);
                db.Persons.Remove(per);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Ef");
        }
    }
}