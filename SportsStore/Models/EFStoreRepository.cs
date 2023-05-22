using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace SportsStore.Models
{
    // implementation class for repository service
    public class EFStoreRepository : IStoreRepository
    {
        // a private instance variable of type StoreDbContext that is used to access the database
        private readonly StoreDbContext _context;

        // constructor for the EFStoreRepository class that takes a StoreDbContext object as a parameter
        public EFStoreRepository(StoreDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Product> Products => _context.Products; // maps Products property defined by IStoreRepository interface onto Products property-
                                                                  // defined by the StoreDbContext class
                                                                  // this effectively allows the Products property in the context class to return a DbSet<Product> object (implements IQueryable<T>)-
                                                                  // and hence makes it easy to implement the repository service when using EF core.

        // implementation of the Products property defined by the IStoreRepository interface
        // this property maps onto the Products property of the StoreDbContext class and returns a DbSet<Product> object
        // which implements the IQueryable<Product> interface

    }
}