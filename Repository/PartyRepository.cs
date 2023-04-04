
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PartyProductAPI.Data;
using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public class PartyRepository : IPartyRepository
    {
        private readonly InvoiceAppContext _context;
        private readonly IMapper _mapper;

        public PartyRepository(InvoiceAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PartyModel>> GetAllParty()
        {
            //var result = await _context.Parties.Select(x => new PartyModel()
            //{
            //    PartyId = x.PartyId,
            //    PartyName = x.PartyName,
            //}).ToListAsync();

            //return result;

            var result = await _context.Parties.ToListAsync();
            return _mapper.Map<List<PartyModel>>(result);
        }

        public async Task<PartyModel> GetPartyById(int id)
        {
            //var result = await _context.Parties.Where(x => x.PartyId == id).Select(x => new PartyModel()
            //{
            //    PartyId = x.PartyId,
            //    PartyName = x.PartyName,
            //}).FirstOrDefaultAsync();

            //return result;

            var result = await _context.Parties.FindAsync(id);
            return _mapper.Map<PartyModel>(result);
        }

        public async Task<int> AddNewParty(PartyModel party)
        {
            var newParty = new Party()
            {
                PartyName = party.PartyName,
            };
            await _context.AddAsync(newParty);
            await _context.SaveChangesAsync();
            return newParty.PartyId;
        }

        public async Task<int> UpdateParty(int id, PartyModel party)
        {
            var findParty = await _context.Parties.FindAsync(id);

            if (findParty != null)
            {
                findParty.PartyName = party.PartyName;

                await _context.SaveChangesAsync();

            }
            return id;
        }

        public async Task DeleteParty(int id)
        {
            var party = new Party()
            {
                PartyId = id
            };

            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();
        }
    }
}
