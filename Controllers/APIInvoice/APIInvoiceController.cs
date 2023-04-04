using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.APIInvoice
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class APIInvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public APIInvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoice()
        {
            var result = await _invoiceRepository.GetAllInvoiceAsync();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

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

        [HttpPost]
        public async Task<IActionResult> AddNewInvoice([FromBody] InvoiceModel invoice)
        {
            var newInvoice = await _invoiceRepository.AddNewInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = newInvoice, controller = "Invoice" }, await GetInvoiceById(newInvoice));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateInvoice([FromRoute] int id, [FromBody] InvoiceModel invoice)
        {
            await _invoiceRepository.UpdateInvoiceAsync(id, invoice);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice()
        {
            await _invoiceRepository.DeleteInvoiceAsync();
            return Ok();
        }
    }
}
