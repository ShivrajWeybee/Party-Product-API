using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PartyProductAPI.Data;
using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceAppContext _context;
        private readonly IMapper _mapper;

        public InvoiceRepository(InvoiceAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InvoiceModel>> GetAllInvoiceAsync()
        {
            //var result = await _context.Invoices.Select(x => new InvoiceModel()
            //{
            //    InvoiceId = x.InvoiceId,
            //    PartyId = x.PartyId,
            //    ProductId = x.ProductId,
            //    Quantity = x.Quantity,
            //    Rate = x.Rate,
            //    Total = x.Total,
            //}).ToListAsync();

            //return result;

            var result = await _context.Invoices.ToListAsync();
            return _mapper.Map<List<InvoiceModel>>(result);
        }

        public async Task<InvoiceModel> GetInvoiceByIdAsync(int id)
        {
            //var result = await _context.Invoices.Where(x => x.InvoiceId == id).Select(x => new InvoiceModel()
            //{
            //    InvoiceId = x.InvoiceId,
            //    PartyId = x.PartyId,
            //    ProductId = x.ProductId,
            //    Quantity = x.Quantity,
            //    Rate = x.Rate,
            //    Total = x.Total,
            //}).FirstOrDefaultAsync();

            //return result;
            //var result1 = (from o in _context.Parties
            //              join i in _context.PartyProducts
            //              on o.PartyId equals i.PartyId
            //              select new
            //              {
            //                  Name = o.Name,
            //                  Composer = o.Composer
                              
            //              }).Take(5);
            var result = await _context.Invoices.FindAsync(id);
            return _mapper.Map<InvoiceModel>(result);
        }

        public async Task<int> AddNewInvoiceAsync(InvoiceModel invoice)
        {
            var newInvoice = new Invoice()
            {
                PartyId = invoice.PartyId,
                ProductId = invoice.ProductId,
                Quantity = invoice.Quantity,
                Rate = invoice.Rate,
                Total = (invoice.Quantity * invoice.Rate)
            };
            await _context.AddAsync(newInvoice);
            await _context.SaveChangesAsync();
            return newInvoice.InvoiceId;
        }

        public async Task UpdateInvoiceAsync(int id, InvoiceModel invoice)
        {
            var findInvoice = await _context.Invoices.FindAsync(id);

            if (findInvoice != null)
            {
                findInvoice.PartyId = invoice.PartyId;
                findInvoice.ProductId = invoice.ProductId;
                findInvoice.Rate = invoice.Rate;
                findInvoice.Quantity = invoice.Quantity;
                findInvoice.Total = (invoice.Quantity * invoice.Rate);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteInvoiceAsync()
        {
            //var invoice = new Invoice()
            //{
            //    InvoiceId = id
            //};

            _context.Invoices.RemoveRange(_context.Invoices);
            await _context.SaveChangesAsync();
        }
    }
}
