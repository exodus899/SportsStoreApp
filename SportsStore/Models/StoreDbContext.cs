using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class StoreDbContext : DbContext
    {
        // constructor for the StoreDbContext class that takes DbContextOptions as a parameter
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }

        // a property of the StoreDbContext class that returns a DbSet<Product> object
        public DbSet<Product> Products => Set<Product>();
    }
}