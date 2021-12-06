using MvcProjectWmp101.Models;
using MvcProjectWmp101.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        [HttpGet]
        public ActionResult Index()
        {
            Kisi kisi = new Kisi();
            kisi.Ad = "Gizem";
            kisi.Soyad = "Gunes";
            kisi.Yas = 25;

            Adres adr = new Adres();
            adr.AdresTanimi = "Deneme adresi";
            adr.Sehir = "Istanbul";

            indexViewModel mod = new indexViewModel();
            mod.KisiNesnesi = kisi;
            mod.AdresNesnesi = adr;

            return View(mod);
        }

        [HttpPost]
        public ActionResult Index(indexViewModel model)
        {
            return View(model);
        }
    }
}