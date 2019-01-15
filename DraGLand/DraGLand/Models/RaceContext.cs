using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DraGLand.Models
{
    public class RaceContext : DbContext
    {
        public RaceContext() : base("DefaultConnection")
        { }
        public DbSet<Race> Races { get; set; }
    }
}