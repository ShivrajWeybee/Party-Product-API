using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.Invoice
{
    [Route("[controller]/[action]")]
    //[ApiController]
    //[Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPartyRepository _partyRepo;

        public InvoiceController(IInvoiceRepository invoiceRepository, IPartyRepository partyRepo)
        {
            _invoiceRepository = invoiceRepository;
            _partyRepo = partyRepo;
        }

        [ViewData]
        public string Title { get; set; }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoice()
        {
            var result = await _invoiceRepository.GetAllInvoiceAsync();
            return View("Invoice");
        }


        // -------------------------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInvoiceById([FromRoute] int id)
        {
            var result = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // -------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> AddNewInvoice()
        {
            ViewBag.PartyDropdown = (await _partyRepo.GetAllParty()).Select(x => new SelectListItem() { Text = x.PartyName, Value = x.PartyId.ToString() });
            ViewBag.ProductDropdown = "";
            ViewBag.Rate = null;
            ViewBag.Quantity = null;
            return View("Invoice");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInvoice([FromForm] InvoiceModel invoice)
        {
            await _invoiceRepository.AddNewInvoiceAsync(invoice);
            //return Json(new { success = true });
            ViewBag.PartyDropdown = (await _partyRepo.GetAllParty()).Select(x => new SelectListItem() { Text = x.PartyName, Value = x.PartyId.ToString() });
            ViewBag.ProductDropdown = "";
            ViewBag.Rate = null;
            ViewBag.Quantity = null;
            return RedirectToAction("GetAllInvoice");
        }


        // -------------------------------------------------------------------------------
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateInvoice([FromRoute] int id, [FromBody] InvoiceModel invoice)
        {
            await _invoiceRepository.UpdateInvoiceAsync(id, invoice);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteInvoice()
        {
            await _invoiceRepository.DeleteInvoiceAsync();
            return View("Invoice");
        }
    }
}
