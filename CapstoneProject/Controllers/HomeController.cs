using CapstoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.StudentProcessor;

namespace CapstoneProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewStudents()
        {
            ViewBag.Message = "Student List";

            var data = LoadStudents();
            List<StudentModel> students = new List<StudentModel>();

            foreach (var row in data)
            {
                students.Add(new StudentModel
                {
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    BirthDate = row.BirthDate,
                    Phone = row.Phone,
                    Email = row.Email,
                    ConfirmEmail = row.Email
                });
            }

            return View(students);
        }

        public ActionResult StudentRegistration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentRegistration(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                CreateStudent(model.FirstName, model.LastName, model.BirthDate, model.Phone, model.Email);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}