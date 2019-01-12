using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DraGLand.Models
{
    public class CarStoreContext : DbContext
    {
        public CarStoreContext() : base("DefaultConnection")
        { }
        public DbSet<CarStore> CarStores { get; set; }
    }
}