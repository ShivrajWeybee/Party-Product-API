using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRateController : ControllerBase
    {
        private readonly IProductRateRepository _productRateRepository;

        public ProductRateController(IProductRateRepository productRateRepository)
        {
            _productRateRepository = productRateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductRate()
        {
            var result = await _productRateRepository.GetAllProductRateAsync();
            if(result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductRateById([FromRoute] int id)
        {
            var result = await _productRateRepository.GetProductByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductRate([FromBody] ProductRateModel productRate)
        {
            var id = await _productRateRepository.AddNewProductRateAsync(productRate);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductRate([FromRoute]int id, [FromBody] ProductRateModel rate)
        {
            var result = await _productRateRepository.UpdateNewRateAsync(id, rate);
            if(result == true)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductRate([FromRoute] int id)
        {
            await _productRateRepository.DeleteRateAsync(id);
            return Ok();
        }
    }
}
