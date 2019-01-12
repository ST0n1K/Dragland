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

        public System.Data.Entity.DbSet<DraGLand.Models.Car> Cars { get; set; }

        public System.Data.Entity.DbSet<DraGLand.Models.User> Users { get; set; }
    }
}