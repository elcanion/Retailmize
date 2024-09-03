using Retailmize.Domain.Entities;
using Retailmize.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Product> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int? Id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Remove(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
