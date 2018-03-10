using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeInventory1.Models
{
    public class BikeTypeViewModel
    {
        public List<Bike> bikes;
        public SelectList types;
        public string BikeType { get; set; }
    }
}
