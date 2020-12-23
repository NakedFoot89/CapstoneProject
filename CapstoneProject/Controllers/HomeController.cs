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

        //Action method for displaying 'Student Registration' page
        public ActionResult StudentRegistration()
        {
            // get all courses for a DropDownList
            var courseList = GetAllCourses();

            var model = new StudentModel();

            // Create a list of SelectListItems so these can be rendered on the page
            model.CourseList = GetSelectListItems(courseList);

            return View(model);
        }

        // Creates Student from StudentModel with StudentRegistration view.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentRegistration(StudentModel model)
        {
            var courseList = GetAllCourses();

            model.CourseList = GetSelectListItems(courseList);

            if (ModelState.IsValid)
            {
                CreateStudent(model.StudentID, model.FirstName, model.LastName, model.BirthDate, model.Phone, model.Email, model.Course);
                return RedirectToAction("Index");
            }
            // Something is not right - so render the registration page again,
            // keeping the data user has entered by supplying the model.
            return View("StudentRegistration", model);
        }

        // Just return a list of courses - in a real-world application this would call
        // into data access layer to retrieve courses from a database.
        private IEnumerable<string> GetAllCourses()
        {
            return new List<string>
            {
                "Mathematics",
                "Humanities",
                "English",
                "Science",
            };
        }

        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the StudentRegisteration.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="Course Name">Course Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        // Uses LoadStudents() function to retrieve with a SQL statement a List of Students
        public ActionResult ViewStudents()
        {
            ViewBag.Message = "Student List";

            var data = LoadStudents();
            List<StudentModel> students = new List<StudentModel>();

            foreach (var row in data)
            {
                students.Add(new StudentModel
                {
                    StudentID = row.StudentID,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    BirthDate = row.BirthDate,
                    Phone = row.Phone,
                    Email = row.Email,
                    ConfirmEmail = row.Email,
                    Course = row.Course,
                });
            }

            return View(students);
        }


    }
}