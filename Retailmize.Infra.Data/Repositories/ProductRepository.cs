using Retailmize.Domain.Entities;
using Retailmize.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductCategory(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Remove(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
