using IMS.Domain.Entites;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Common.Interfaces
{
    public interface IMongoDbContext
    {     
        IMongoCollection<Company> Companies {get;}
        IMongoCollection<Warehouse> Warehouses {get;}
        IMongoCollection<ItemCategory> ItemCategories {get;}
        IMongoCollection<Item> Items {get;}
        IMongoCollection<Vendor> Vendors {get;}
        IMongoCollection<Customer> Customers {get;}
    }
}
