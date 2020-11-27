using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    //this is a front-end student model
    public class StudentModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The Email and Confirm Email must match.")]
        public string ConfirmEmail {get; set;}

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Your Password must be a minimum of 10 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}