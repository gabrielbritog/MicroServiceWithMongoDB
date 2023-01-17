using MicroServiceWithMongoDb.Entities;
using MongoDB.Driver;

namespace MicroServiceWithMongoDb.Data
{
    public class CatalogContextSeed
    {
        public static void Seed(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product(){
               Id = "62645ds23a1s55",
               Name = "Iphone X",
               Description = "Lorem ipsum dolor sit  amet",
               Image = "procuct-1.png",
               Price = 950.00M,
               Category = "Smart Phone"
            },
                new Product(){
               Id = "135123ds3dasa",
               Name = "Galaxy S20",
               Description = "Lorem ipsum dolor sit  amet",
               Image = "procuct-2.png",
               Price = 750.00M,
               Category = "Smart Phone"
            },
                new Product(){
               Id = "135123ds3dasa",
               Name = "ZenFone",
               Description = "Lorem ipsum dolor sit  amet",
               Image = "procuct-3.png",
               Price = 350.00M,
               Category = "Smart Phone"
            }
            };
        }
    }
}
