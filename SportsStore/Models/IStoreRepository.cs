using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IStoreRepository // a class that depends on the IStoreRepository interface can obtain Product objects without-
    // needing to know the details of how they are stored or how the implementation will retrieve/deliver them
    {
        IQueryable<Product> Products { get; } // derived from IEnumerable<T> interface and represents a collection of objects that can be queried,
                                              // such as those managed by a database 


        //** without this interface, retrieving Product objects would be a tiresome and more difficult operation
        // you'd have to discard the objects you don't want

        // one caveat to be aware of, each time IQueryable<T> interface enumerates a collection of objects, the query is evaluated again
        //  this means a new query will be sent to the database. This can undermine the efficiency gains of using this interface.
        // converting IQueryable<T> to a more predictable form can be used i.e. ToList, or ToArray extension method if desired.
    }
}