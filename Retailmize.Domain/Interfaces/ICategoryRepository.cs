using Retailmize.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int? Id);
        Task<Product> Create(Category category);
        Task<Product> Update(Category category);
        Task<Product> Remove(Category category);
    }
}
