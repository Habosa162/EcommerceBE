using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteProduct(int id)
        {
            var DelProduct = await _context.Products.FindAsync(id);
            if (DelProduct != null)
            {
                _context.Products.Remove(DelProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _context.Products.Include(p=>p.SubCategory).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Include(p=>p.SubCategory).ToListAsync();
        }

     

        public async Task<IEnumerable<Product>> GetProductsBySubCategoryId(int id)
        {
            return await _context.Products.Where(p => p.SubCategoryId== id).ToListAsync();
        }

        public async Task SetProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
             _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
