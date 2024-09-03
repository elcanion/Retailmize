using Microsoft.EntityFrameworkCore;
using Retailmize.Domain.Entities;
using Retailmize.Domain.Interfaces;
using Retailmize.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> Remove(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
