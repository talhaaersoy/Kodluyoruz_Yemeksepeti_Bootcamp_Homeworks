using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace _4SwaggerAPI.DataAccess
{
    public class RentContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YSRent;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }  

    }
}
