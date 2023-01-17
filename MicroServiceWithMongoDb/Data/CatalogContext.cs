using MicroServiceWithMongoDb.Data.Interface;
using MicroServiceWithMongoDb.Entities;
using MongoDB.Driver;

namespace MicroServiceWithMongoDb.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<Product> Products { get; }

    }
}
