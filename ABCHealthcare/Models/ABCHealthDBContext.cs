using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ABCHealthcare.Models
{
    public class ABCHealthDBContext : DbContext
    {
        public ABCHealthDBContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}