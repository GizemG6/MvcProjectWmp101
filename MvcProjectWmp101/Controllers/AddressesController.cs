using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class AddressesController : Controller
    {
        // GET: Addresses
        public ActionResult NewAddress()
        {
            DatabaseContext db = new DatabaseContext();

            List<SelectListItem> personsList = (from s in db.Persons.ToList()
                    select new SelectListItem()
                    {
                     Text = s.Name + " " + s.SurName,
                     Value = s.Id.ToString()
                    }).ToList();

            //List<Persons> persons = db.Persons.ToList();
            //List<SelectListItem> personslist = new List<SelectListItem>();
            //foreach (Persons person in persons)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = person.Name + " " + person.SurName;
            //    item.Value = person.Id.ToString();
            //    personslist.Add(item);
            //}
            TempData["persons"] = personsList;
            ViewBag.persons = personsList;
            return View();
        }
        [HttpPost]
        public ActionResult NewAddress(Addresses address)
        {
            DatabaseContext db = new DatabaseContext();
            Persons person = db.Persons.FirstOrDefault(x => x.Id == address.Persons.Id);
            if (person!=null)
            {
                address.Persons = person;
                db.Addresses.Add(address);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Address enrollment completed successfully.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Address enrollment failure.";
                    ViewBag.Status = "danger";
                }
            }
            ModelState.Clear();
            ViewBag.persons = TempData["persons"];
            return View();
        }
    }
}