using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace CapstoneProject.Models
{
    //this is a front-end student model
    public class StudentModel
    {
        [Range(10000, 99999)]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The Email and Confirm Email must match.")]
        public string ConfirmEmail {get; set;}

        [Display(Name = "Course")]
        public string Course { get; set; }

        //SelectListItem holds a list of courses for the user to select
        public IEnumerable<SelectListItem> CourseList { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Your Password must be a minimum of 10 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}