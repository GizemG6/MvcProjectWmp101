using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult NewStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewStudent(Students students)
        {
            studentDatabaseContext db = new studentDatabaseContext();
            Classes classes1 = db.Classes.FirstOrDefault(x => x.Id == students.Classes.Id);
            if (classes1 != null)
            {
                students.Classes = classes1;
                db.Students.Add(students);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Student enrollment completed successfully.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Student enrollment failure.";
                    ViewBag.Status = "danger";
                }
            }
            ModelState.Clear();
            ViewBag.students = TempData["students"];
            return View();
        }
    }
}