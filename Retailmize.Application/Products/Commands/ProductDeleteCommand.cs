using MediatR;
using Retailmize.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Application.Products.Commands
{
    public class ProductDeleteCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
