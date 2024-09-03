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
            throw new NotImplementedException();
        }

        public async Task<Category> GetById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Remove(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
