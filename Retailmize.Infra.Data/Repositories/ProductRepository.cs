using Microsoft.EntityFrameworkCore;
using Retailmize.Domain.Entities;
using Retailmize.Domain.Interfaces;
using Retailmize.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retailmize.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategory(int? id)
        {
            return await _context.Products.Include(x => x.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Remove(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
