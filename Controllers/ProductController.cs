using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productRepository.GetAllProduct();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var result = _productRepository.GetProductById(id).Result;
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductModel product)
        {
            var newProduct = await _productRepository.AddNewProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct, controller = "Product"}, GetProductById(newProduct));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel product)
        {
            await _productRepository.UpdateProduct(id, product);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok();
        }
    }
}
