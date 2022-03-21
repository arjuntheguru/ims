using IMS.Application.Common.Interfaces;
using IMS.Application.Common.Settings;
using IMS.Domain.Entites;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Persistence
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private DatabaseSettingOption _databaseSetting;
        public MongoDbContext(IOptions<DatabaseSettingOption> options)
        {
            _databaseSetting = options.Value;
            _database = new MongoClient(_databaseSetting.ConnectionString).GetDatabase(_databaseSetting.DatabaseName);
        }    
        public IMongoCollection<Company> Companies => _database.GetCollection<Company>("Company");
        public IMongoCollection<Warehouse> Warehouses => _database.GetCollection<Warehouse>("Warehouses");
        public IMongoCollection<ItemCategory> ItemCategories => _database.GetCollection<ItemCategory>("ItemCategories");
        public IMongoCollection<Item> Items => _database.GetCollection<Item>("Items");
        public IMongoCollection<Vendor> Vendors => _database.GetCollection<Vendor>("Vendors");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");


    }
}
