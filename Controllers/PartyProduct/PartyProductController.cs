using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.PartyProduct
{
    [Route("[controller]/[action]")]
    //[ApiController]
    //[Authorize]
    public class PartyProductController : Controller
    {
        private readonly IPartyProductRepository _partyProductRepository;
        private readonly IPartyRepository _partyRepository;
        private readonly IProductRepository _productRepository;

        public PartyProductController(IPartyProductRepository partyProductRepository, IPartyRepository partyRepository, IProductRepository productRepository)
        {
            _partyProductRepository = partyProductRepository;
            _partyRepository = partyRepository;
            _productRepository = productRepository;
        }

        [ViewData]
        public string Title { get; set; }


        // -------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAllAssign()
        {
            var result = await _partyProductRepository.GetAllAssignAsync();

            //if (result.Count > 0)
            //{
            //    return Ok(result);
            //}
            //return NoContent();

            Title = "Assign | Invoice App";
            return View("GetAllAssign", result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAssignById(int id)
        {
            var result = await _partyProductRepository.GetAssignById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }


        // -------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> AddNewAssign()
        {
            return View("AddNewAssign");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAssign([FromForm] PartyProductModel assign)
        {
            await _partyProductRepository.AddNewAssignAsync(assign);
            return View("AddNewAssign");
        }


        // -------------------------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<IActionResult> UpdateAssign([FromRoute] int id)
        {
            var tempParty = await _partyProductRepository.GetAssignById(id);
            ViewBag.SelectedParty = tempParty.PartyId;
            ViewBag.SelectedProduct = tempParty.ProductId;
            return View();
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> UpdateAssign([FromRoute] int id, [FromForm] PartyProductModel assign)
        {
            await _partyProductRepository.UpdateAssignAsync(id, assign);
            var tempParty = await _partyProductRepository.GetAssignById(id);
            ViewBag.SelectedParty = tempParty.PartyId;
            ViewBag.SelectedProduct = tempParty.ProductId;
            return View();
        }



        // -------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> DeleteAssign(int id)
        {
            await _partyProductRepository.DeleteAssignAsync(id);
            return View("GetAllAssign");
        }


        // -------------------------------------------------------------------------------
        [HttpPost("{id}")]
        public async Task<IActionResult> BindProduct(string id)
        {
            var resultProduct = await _partyProductRepository.BindProduct(id);
            return Json(resultProduct);
        }
    }
}
