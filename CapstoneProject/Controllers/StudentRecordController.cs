using CapstoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CapstoneProject.Controllers
{
    public class StudentRecordController : Controller
    {
        // GET: StudentRecord
        public ActionResult Index()
        {
            return View();
        }

        //Action method for displaying 'StudentRecord' page
        public ActionResult StudentRecord()
        {
            //gets courses to populate dropdown list
            var Courses = GetAllCourses();
            var model = new StudentRecordModel();
            //gets list of SelectListItems
            model.Courses = GetOptionCoursesList(Courses);
            return View(model);
        }

        //Action method for handling student-entered data when 'StudentRecord' button is pressed.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentRecord(StudentRecordModel model)
        {
            var Courses = GetAllCourses();
            model.Courses = GetOptionCoursesList(Courses);
            if (ModelState.IsValid)
            {
                Session["StudentRecordModel"] = model;
                return RedirectToAction("Successfull");
            }
            return View("StudentRecord", model);
        }

        //Action method for displaying 'Successful' page
        public ActionResult Successfull()
        {
            var model = Session["StudentRecordModel"] as StudentRecordModel;
            return View(model);
        }

        //returns list of courses for populating drop down menu
        private IEnumerable<string> GetAllCourses()
        {
            return new List<string>
            {
                "English",
                "Science",
                "Mathematics",
                "Humanities",
            };
        }

        //reads and returns input of course selection
        private IEnumerable<SelectListItem> GetOptionCoursesList(IEnumerable<string> elements)
        {
            var CourseList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                CourseList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return CourseList;
        }
    }
}