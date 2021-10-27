using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pointOfSales.Models
{
    public class Invoice
    {
        [Display(Name = "Invoice ID")]
        public int InvoiceID { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Total Invoice")]
        public Double Total { get; set; }

        //public virtual List<Product> Products { get; set; }
    }
}