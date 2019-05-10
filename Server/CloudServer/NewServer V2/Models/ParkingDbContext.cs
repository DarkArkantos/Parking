﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NewServer_V2.Models
{
    public class ParkingDbContext:DbContext
    {
        public ParkingDbContext(DbContextOptions options) :base(options){
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Place>().ToTable("Places");
            builder.Entity<Car>().ToTable("Cars");
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public int PlaceNumber { get; set; }
        public ICollection<Car> Records { get; set; }
        public bool State { get; set; }
    }
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Owner { get; set; }
        public DateTime Input { get; set; }
        public DateTime Output { get; set; }

        public Place Place { get; set; }
        public int PlaceId { get; set; }
    }
}
