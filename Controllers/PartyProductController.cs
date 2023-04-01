using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Data;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.IO;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyProductController : ControllerBase
    {
        private readonly IPartyProductRepository _partyProductRepository;

        public PartyProductController(IPartyProductRepository partyProductRepository)
        {
            _partyProductRepository = partyProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssign()
        {
            var result = await _partyProductRepository.GetAllAssignAsync();

            if(result.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAssignById(int id)
        {
            var result = await _partyProductRepository.GetAssignById(id);

            if(result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAssign([FromBody] PartyProductModel assign)
        {
            var newAssignId = await _partyProductRepository.AddNewAssignAsync(assign);
            return Ok(newAssignId);
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
    }
}
