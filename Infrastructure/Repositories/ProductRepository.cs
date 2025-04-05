using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommercev.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var DelProduct = await _context.Products.FindAsync(id);
            if (DelProduct != null)
            {
                _context.Products.Remove(DelProduct);
                return await _context.SaveChangesAsync()>0;
                
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetMostSellingProducts(int count)
        {
            var topProductIds = _context.OrderItems
         .GroupBy(o => o.ProductId)
         .Select(g => new
         {
             ProductId = g.Key,
             TotalSold = g.Sum(o => o.Qty)
         })
         .OrderByDescending(g => g.TotalSold)
         .Take(6) 
         .Select(g => g.ProductId) 
         .ToList();

            var topProducts =  _context.Products
                .Where(p => topProductIds.Contains(p.Id))
                .ToList();
            return topProducts;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.Include(p=>p.SubCategory).Include(p=>p.SubCategory.Category).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Include(p=>p.SubCategory).Include(p=>p.SubCategory.Category).ToListAsync();
        }

     

        public async Task<IEnumerable<Product>> GetProductsBySubCategoryId(int id)
        {
            return await _context.Products.Where(p => p.SubCategoryId== id).ToListAsync();
        }

        public async Task<Product> SetProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
             _context.Products.Update(product);
            return await _context.SaveChangesAsync()>0;
        }
    }
}
