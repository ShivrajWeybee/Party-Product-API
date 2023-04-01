﻿using Microsoft.EntityFrameworkCore;
using PartyProductAPI.Data;
using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public class PartyProductRepository : IPartyProductRepository
    {
        private readonly InvoiceAppContext _context;

        public PartyProductRepository(InvoiceAppContext context)
        {
            _context = context;
        }

        public async Task<List<PartyProductModel>> GetAllAssignAsync()
        {
            var result = await _context.PartyProducts.Select(x => new PartyProductModel()
            {
                Id = x.Id,
                PartyId = x.PartyId,
                ProductId = x.ProductId,
            }).ToListAsync();

            return result;
        }

        public async Task<PartyProductModel> GetAssignById(int id)
        {
            var result = await _context.PartyProducts.Where(x => x.Id == id).Select(x => new PartyProductModel()
            {
                Id = x.Id,
                PartyId = x.PartyId,
                ProductId = x.ProductId,
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> AddNewAssignAsync(PartyProductModel assign)
        {
            var newAssign = new PartyProduct()
            {
                Id = assign.Id,
                PartyId = assign.PartyId,
                ProductId = assign.ProductId,
            };

            await _context.AddAsync(newAssign);
            await _context.SaveChangesAsync();

            return newAssign.Id;
        }

        public async Task UpdateAssignAsync(int id, PartyProductModel assign)
        {
            var findParty = await _context.PartyProducts.FindAsync(id);

            if (findParty != null)
            {
                findParty.ProductId = assign.ProductId;
                findParty.PartyId = assign.PartyId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAssignAsync(int id)
        {
            var assign = new PartyProduct()
            {
                Id = id
            };

            _context.PartyProducts.Remove(assign);
            await _context.SaveChangesAsync();
        }
    }
}
