using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using pointOfSales.Models;

namespace point_of_sales.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        //[Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Email Address Required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        //[Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirmation Password is required.")]
        [Display(Name = "Re-Type Password")]
        //[Compare("password", ErrorMessage = "Password and Confirmation Password must match.")]
        [DataType(DataType.Password)]
        public string Re_typePassword { get; set; }

        public string Role { get; set; }

    }
    
}