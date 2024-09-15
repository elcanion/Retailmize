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
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(command.Id);
            if (product == null)
            {
                throw new ApplicationException($"Error updating product");
            }
            else
            {
                product.Update(command.Name, command.Description, command.Price, command.Stock, command.Image, command.CategoryId);
                return await _productRepository.Update(product);
            }
        }
    }
}
