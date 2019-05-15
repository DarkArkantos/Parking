using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerLocal.Model
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>().ToTable("Cars");
            //builder.Entity<Enrollment>().ToTable("Enrollments");
        }
        public DbSet<Car> Cars { get; set; }
    }
}
