using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.Product
{
    [Route("[controller]/[action]")]
    //[ApiController]
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [ViewData]
        public string Title { get; set; }


        // ---------------------------------------------------------------
        //[HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productRepository.GetAllProduct();
            //return Ok(result);
            Title = "Product | Invoice App";
            return View("GetAllProduct", result);
        }

        //[HttpGet("{id:int}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var result = _productRepository.GetProductById(id).Result;
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // ---------------------------------------------------------------
        public async Task<ViewResult> AddNewProduct()
        {
            ViewBag.Success = false;
            return View("AddNewProduct");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddNewProduct(product);
                ViewBag.Success = true;
            }
            else
            {
                ViewBag.Success = false;
            }
            return View("AddNewProduct");
        }


        // ---------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<ViewResult> UpdateProduct(int id)
        {
            var findProduct = await _productRepository.GetProductById(id);
            ViewBag.Product = findProduct;
            ViewBag.Success = false;
            return View("UpdateProduct");
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateProduct(id, product);
                ViewBag.Success = true;
            }
            else
            {
                ViewBag.Success = false;
            }

            ViewBag.Product = product;
            return View("UpdateProduct");
        }


        // ---------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return View("GetAllProduct");
        }
    }
}
