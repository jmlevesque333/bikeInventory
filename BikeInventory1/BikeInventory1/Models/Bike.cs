using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeInventory1.Models
{
    public class Bike
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Type")]
        public string BikeType { get; set; }
        public decimal Rating { get; set; }

        [Display(Name = "Quantity available")]
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
