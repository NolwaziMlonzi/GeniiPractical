using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pointOfSales.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name = "Item")]
        public string ItemName { get; set; }
        [Display(Name = "Cost Of Item")]
        public double CostPerItem { get; set; }
        [Display(Name = "Products In Stock")]
        public int ProductsInStock { get; set; }

        public virtual Invoice Invoice { get; set; }

    }
}