using Microsoft.EntityFrameworkCore;
using PartyProductAPI.Data;
using PartyProductAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InvoiceAppContext _context;

        public ProductRepository(InvoiceAppContext context)
        {
            _context = context;
        }
        public async Task<List<ProductModel>> GetAllProduct()
        {
            var result = await _context.Products.Select(x => new ProductModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
            }).ToListAsync();
            return result;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var result = await _context.Products.Where(x => x.ProductId == id).Select(x => new ProductModel()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> AddNewProduct(ProductModel product)
        {
            var newProduct = new Product()
            {
                ProductName = product.ProductName,
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.ProductId;
        }

        public async Task UpdateProduct(int id, ProductModel product)
        {
            var findProduct = await _context.Products.FindAsync(id);

            if(findProduct != null)
            {
                findProduct.ProductName = product.ProductName;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = new Product()
            {
                ProductId = id,
            };

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
