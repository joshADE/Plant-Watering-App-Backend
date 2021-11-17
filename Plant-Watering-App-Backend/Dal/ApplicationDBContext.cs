
using Microsoft.EntityFrameworkCore;
using Plant_Watering_App_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Watering_App_Backend.Dal
{
    public class ApplicationDBContext : DbContext
    {
        
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Plant Table
            modelBuilder.Entity<Plant>()
                .Property(p => p.status)
                .HasConversion<int>();
        }
    }
}
