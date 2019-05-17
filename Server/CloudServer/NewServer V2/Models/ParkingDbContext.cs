using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewServer_V2.Models
{
    public class ParkingDbContext:DbContext
    {

        /**
         * Create a new table that connect Places and Cars!!!!!!
         */
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options) :base(options){
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Place>().ToTable("Places");
            builder.Entity<Car>().ToTable("Cars").HasOne<Place>(p => p.Place).WithMany(c => c.Cars).HasForeignKey(p => p.PlaceId);
            //builder.Entity<Enrollment>().ToTable("Enrollments");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=tcp:parkingutadeoserver.database.windows.net,1433;Initial Catalog=ParkingUtadeoDb2019;Persist Security Info=False;User ID={parkingutadeo};Password={Kirchoff.322/};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Car> Cars { get; set; }
       // public DbSet<Enrollment> Enrollments { get; set; }
    }
    public class Place
    {
        public Place()
        {
            Cars= new HashSet<Car>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlaceId { get; set; }
        public int PlaceNumber { get; set; }
        public bool State { get; set; }

        [ForeignKey("CarId")]
        public ICollection<Car> Cars { get; set; }
        //public ICollection<Enrollment> Enrollments { get; set; }

    }
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string LicensePlate { get; set; }
        public string Owner { get; set; }
        public DateTime Input { get; set; }
        public DateTime Output { get; set; }

        public virtual int PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
    }
    /*public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CarID { get; set; }
        public int PlaceID { get; set; }

        public Car Car { get; set; }
        public Place Place { get; set; }
    }*/
}
