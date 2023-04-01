using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Data;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoice()
        {
            var result = await _invoiceRepository.GetAllInvoiceAsync();
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            await _invoiceRepository.DeleteInvoiceAsync(id);
            return Ok();
        }
    }
}
