using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pointOfSales.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        [Display(Name = "Item")]
        public string ItemName { get; set; }
        [Display(Name = "Cost Per Item")]
        public Double CostPerItem { get; set; }
        [Display(Name = "Total Cost")]
        public Double TotalCost { get; set; }
        [Display(Name = "Total Amount")]
        public Double TotalAmount { get; set; }

        public virtual Invoice Invoice { get; set; }

    }
}