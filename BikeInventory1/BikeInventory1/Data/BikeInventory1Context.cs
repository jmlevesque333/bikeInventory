using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BikeInventory1.Models
{
    public class BikeInventory1Context : DbContext
    {
        public BikeInventory1Context (DbContextOptions<BikeInventory1Context> options)
            : base(options)
        {
        }

        public DbSet<BikeInventory1.Models.Bike> Bike { get; set; }
    }
}
