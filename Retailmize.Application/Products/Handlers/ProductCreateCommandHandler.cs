using MediatR;
using Retailmize.Application.Products.Commands;
using Retailmize.Domain.Entities;
using Retailmize.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Retailmize.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Description, command.Price, command.Stock, command.Image);
            if (product == null)
            {
                throw new ApplicationException($"Error creating product");
            }
            else
            {
                product.CategoryId = command.CategoryId;
                return await _productRepository.Create(product);
            }
        }
    }
}
