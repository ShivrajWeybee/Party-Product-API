using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyRepository _partyRepository;

        public PartyController(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParty()
        {
            var result = await _partyRepository.GetAllParty();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPartyById([FromRoute] int id)
        {
            var result = await _partyRepository.GetPartyById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewParty([FromBody] PartyModel party)
        {
            var newParty = await _partyRepository.AddNewParty(party);
            return CreatedAtAction(nameof(GetPartyById), new { id = newParty, controller="Party" }, await GetPartyById(newParty));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateParty([FromRoute] int id, [FromBody] PartyModel party)
        {
            await _partyRepository.UpdateParty(id, party);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteParty(int id)
        {
            await _partyRepository.DeleteParty(id);
            return Ok();
        }
    }
}
