using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public interface IProductRateRepository
    {
        Task<List<ProductRateModel>> GetAllProductRateAsync();
        Task<ProductRateModel> GetProductByIdAsync(int id);
        Task<int> AddNewProductRateAsync(ProductRateModel productRate);
        Task<bool> UpdateNewRateAsync(int id, ProductRateModel rate);
        Task DeleteRateAsync(int id);
        Task<ProductRateModel> BindRate(string id);
        Task<double> GetGrandTotal();
    }
}