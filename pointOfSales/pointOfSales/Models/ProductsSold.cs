using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pointOfSales.Models
{
    public class ProductsSold
    {
        [Key]
        public int ProductSoldID { get; set; }
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        [Display(Name = "Total Sold")]
        public double sold { get; set; }
        [Display(Name = "Total InStock")]
        public double InStock { get; set; }

        [Display(Name = "Re-Stock")]
        public bool ReStock { get; set; }
        public virtual Product Product{ get; set; }
    }
}