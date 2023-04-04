using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.APIPartyProduct
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class APIPartyProductController : ControllerBase
    {
        private readonly IPartyProductRepository _partyProductRepository;

        public APIPartyProductController(IPartyProductRepository partyProductRepository)
        {
            _partyProductRepository = partyProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssign()
        {
            var result = await _partyProductRepository.GetAllAssignAsync();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NoContent();
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

        [HttpPost]
        public async Task<IActionResult> AddNewAssign([FromBody] PartyProductModel assign)
        {
            var newAssign = await _partyProductRepository.AddNewAssignAsync(assign);
            return Ok(newAssign);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAssign([FromRoute] int id, [FromBody] PartyProductModel assign)
        {
            await _partyProductRepository.UpdateAssignAsync(id, assign);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAssign([FromRoute] int id)
        {
            await _partyProductRepository.DeleteAssignAsync(id);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> BindProduct(string id)
        {
            var resultProduct = await _partyProductRepository.BindProduct(id);
            return Ok();
        }
    }
}
