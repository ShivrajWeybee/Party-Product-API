using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public interface IInvoiceRepository
    {
        Task<int> AddNewInvoiceAsync(InvoiceModel invoice);
        Task DeleteInvoiceAsync();
        Task<List<InvoiceModel>> GetAllInvoiceAsync();
        Task<InvoiceModel> GetInvoiceByIdAsync(int id);
        Task UpdateInvoiceAsync(int id, InvoiceModel invoice);
    }
}