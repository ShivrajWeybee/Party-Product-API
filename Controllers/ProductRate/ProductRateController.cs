using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.ProductRate
{
    [Route("[controller]/[action]")]
    //[ApiController]
    //[Authorize]
    public class ProductRateController : Controller
    {
        private readonly IProductRateRepository _productRateRepository;

        public ProductRateController(IProductRateRepository productRateRepository)
        {
            _productRateRepository = productRateRepository;
        }

        [ViewData]
        public string Title { get; set; }


        // -------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAllProductRate()
        {
            var result = await _productRateRepository.GetAllProductRateAsync();
            //if (result == null)
            //{
            //    return NoContent();
            //}
            //return Ok(result);

            Title = "Product Rate | Invoice App";
            return View("GetAllProductRate", result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductRateById([FromRoute] int id)
        {
            var result = await _productRateRepository.GetProductByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // -------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> AddNewProductRate()
        {
            ViewBag.Success = false;
            return View("AddNewProductRate");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductRate([FromForm] ProductRateModel productRate)
        {
            if (ModelState.IsValid)
            {
                await _productRateRepository.AddNewProductRateAsync(productRate);
                ViewBag.Success = true;
            }
            else
            {
                ViewBag.Success = false;
            }
            return RedirectToAction("AddNewProductRate");
        }


        // -------------------------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<IActionResult> UpdateProductRate([FromRoute] int id)
        {
            var findRate = await _productRateRepository.GetProductByIdAsync(id);
            ViewBag.Rate = findRate;
            return View("UpdateProductRate");
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> UpdateProductRate([FromRoute] int id, [FromForm] ProductRateModel productRateate)
        {
            var result = await _productRateRepository.UpdateNewRateAsync(id, productRateate);
            var findRate = await _productRateRepository.GetProductByIdAsync(id);
            ViewBag.Rate = findRate;
            return View();
        }


        // -------------------------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<IActionResult> DeleteProductRate([FromRoute] int id)
        {
            await _productRateRepository.DeleteRateAsync(id);
            return View("GetAllProductRate");
        }


        // -------------------------------------------------------------------------------
        [HttpPost("{id}")]
        public async Task<IActionResult> BindRate(string id)
        {
            var rateFind = await _productRateRepository.BindRate(id);
            return Json(rateFind);
        }
    }
}
