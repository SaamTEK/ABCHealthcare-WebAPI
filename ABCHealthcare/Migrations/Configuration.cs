namespace ABCHealthcare.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ABCHealthcare.Models.ABCHealthDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ABCHealthcare.Models.ABCHealthDBContext context)
        {
            context.Categories.AddOrUpdate(x => x.Id,
                new Models.Category() { Id = 1, Name = "Analgesics" },
                new Models.Category() { Id = 2, Name = "Antacids" },
                new Models.Category() { Id = 3, Name = "Antibacterials" }
                );

            context.Medicines.AddOrUpdate(x => x.Id,
                new Models.Medicine() { Id = 1, Name = "Codeine", Availability = true, Description = "For instant pain relief", Image = "", Price = 25.55, Seller = "MedPlus", CategoryId = 1 },
                new Models.Medicine() { Id = 2, Name = "Pepto-Bismol", Availability = true, Description = "For acidic relief", Image = "", Price = 20, Seller = "MedPlus", CategoryId = 2 },
                new Models.Medicine() { Id = 2, Name = "Penicillin ", Availability = false, Description = "For bacterial infection", Image = "", Price = 50, Seller = "MedPlus", CategoryId = 3 }
                );

            context.Users.AddOrUpdate(x => x.Id,
                new Models.User() { Id = 1, Fullname = "John Doe", UserName = "John", Password = "password", Address = "#123, New Road, New Delhi", Email = "john@gmail.com", Roles = "Admin" }
                );
        }
    }
}
