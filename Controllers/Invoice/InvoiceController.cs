using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.Invoice
{
    [Route("[controller]/[action]")]
    //[ApiController]
    //[Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
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
            return View("Invoice");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInvoice([FromForm] InvoiceModel invoice)
        {
            var newInvoice = await _invoiceRepository.AddNewInvoiceAsync(invoice);
            //return CreatedAtAction(nameof(GetInvoiceById), new { id = newInvoice, controller = "Invoice" }, await GetInvoiceById(newInvoice));
            return View("Invoice");
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
