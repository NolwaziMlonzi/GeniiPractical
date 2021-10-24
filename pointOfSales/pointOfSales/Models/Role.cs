using point_of_sales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pointOfSales.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        [Required(ErrorMessage = "Role Description Required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "User Type Required")]
        [Display(Name = "User Type")]
        public string UserType { get; set; }
        
    }
}