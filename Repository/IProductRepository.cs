using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProduct();
        Task<ProductModel> GetProductById(int id);
        Task<int> AddNewProduct(ProductModel product);
        Task UpdateProduct(int id, ProductModel product);
        Task DeleteProduct(int id);
    }
}