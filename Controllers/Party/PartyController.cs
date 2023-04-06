using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductAPI.Models;
using PartyProductAPI.Repository;
using System.Threading.Tasks;

namespace PartyProductAPI.Controllers.Party
{
    [Route("[controller]/[action]")]
    //[ApiController]
    //[Authorize]
    public class PartyController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly IPartyRepository _partyRepository;

        public PartyController(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }


        // ---------------------------------------------------------------
        [Route("~/")]
        public async Task<IActionResult> GetAllParty()
        {
            var result = await _partyRepository.GetAllParty();
            //return Ok(result);
            Title = "Party | Invoice App";
            return View("GetAllParty", result);
        }


        // ---------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPartyById([FromRoute] int id)
        {
            var result = await _partyRepository.GetPartyById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // ---------------------------------------------------------------
        [HttpGet]
        public async Task<ViewResult> AddNewParty()
        {
            ViewBag.Success = false;
            return View("AddNewParty");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewParty([FromForm] PartyModel party)
        {
            if (ModelState.IsValid)
            {
                await _partyRepository.AddNewParty(party);
                ViewBag.Success = true;
                return View("AddNewParty");
            }
            ViewBag.Success = false;
            return View("AddNewParty");
        }


        // ---------------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<ViewResult> UpdateParty(int id)
        {
            var findParty = await _partyRepository.GetPartyById(id);
            ViewBag.Party = findParty;
            ViewBag.Success = false;
            return View("UpdateParty");
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> UpdateParty([FromRoute] int id, [FromForm] PartyModel party)
        {
            if (ModelState.IsValid)
            {
                await _partyRepository.UpdateParty(id, party);
                ViewBag.Success = true;
            }
            else
            {
                ViewBag.Success = false;
            }

            ViewBag.Party = party;
            return View("UpdateParty");
        }


        // ---------------------------------------------------------------
        [HttpGet]
        //[Route("{id:int}")]
        public async Task<IActionResult> DeleteParty(int id)
        {
            await _partyRepository.DeleteParty(id);
            return View("GetAllParty");
            //return RedirectToAction(actionName: "GetAllParty", controllerName: "Party");
        }
    }
}
