using MicroServiceWithMongoDb.Entities;
using MongoDB.Driver;

namespace MicroServiceWithMongoDb.Data.Interface
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
