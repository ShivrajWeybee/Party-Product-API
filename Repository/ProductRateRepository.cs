using Microsoft.EntityFrameworkCore;
using PartyProductAPI.Data;
using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public class ProductRateRepository : IProductRateRepository
    {
        private readonly InvoiceAppContext _context;

        public ProductRateRepository(InvoiceAppContext context)
        {
            _context = context;
        }

        public async Task<List<ProductRateModel>> GetAllProductRateAsync()
        {
            var result = await _context.ProductRates.Select(x => new ProductRateModel()
            {
                PrtId = x.PrtId,
                ProductID = x.ProductId,
                Rate = x.Rate,
                DateOfRate = x.DateOfRate,
            }).ToListAsync();

            return result;
        }

        public async Task<ProductRateModel> GetProductByIdAsync(int id)
        {
            var result = await _context.ProductRates.Where(x => x.PrtId == id).Select(x => new ProductRateModel()
            {
                PrtId = x.PrtId,
                ProductID = x.ProductId,
                Rate = x.Rate,
                DateOfRate = x.DateOfRate,
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> AddNewProductRateAsync(ProductRateModel productRate)
        {
            var newRate = new ProductRate()
            {
                PrtId = productRate.PrtId,
                ProductId = productRate.ProductID,
                Rate = productRate.Rate,
                DateOfRate = System.DateTime.Now,
            };

            _context.ProductRates.Add(newRate);
            await _context.SaveChangesAsync();

            return newRate.PrtId;
        }

        public async Task<bool> UpdateNewRateAsync(int id, ProductRateModel rate)
        {
            var findRate = await _context.ProductRates.FindAsync(id);
            if(findRate != null)
            {
                findRate.Rate = rate.Rate;
                findRate.ProductId = rate.ProductID;

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task DeleteRateAsync(int id)
        {
            var findRate = new ProductRate()
            {
                PrtId = id,
            };

            _context.ProductRates.Remove(findRate);
            await _context.SaveChangesAsync();
        }
    }
}
