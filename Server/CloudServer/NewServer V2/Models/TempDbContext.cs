using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewServer_V2.Models
{
    public class TempDbContext:DbContext
    {
        public TempDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Dato> Temp { get; set; }
    }
}
