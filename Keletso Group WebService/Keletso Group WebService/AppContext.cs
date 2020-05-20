using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keletso_Group_WebService.Entities;

namespace Keletso_Group_WebService
{
    public class AppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        { }
    }
}
