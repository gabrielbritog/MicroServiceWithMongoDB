using MicroServiceWithMongoDb.Data.Interface;
using MicroServiceWithMongoDb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceWithMongoDb.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public CatalogController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _repository.GetProduct(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductByCategory(string category)
        {
            if (category is null)
            {
                return BadRequest("Invalid category");
            }
            var product = await _repository.GetProductByCategory(category);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            if (product is null)
            {
                return BadRequest("Invalid product");
            }
            await _repository.CreateProduct(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            if (product is null)
            {
                return BadRequest("Invalid product");
            }

            return Ok(await _repository.UpdateProduct(product));
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult<Product>> DeleteProductById(string id)
        {

            return Ok(await _repository.DeleteProduct(id));
        }
    }
}
