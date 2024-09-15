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
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductDeleteCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(command.Id);

            if (product == null)
            {
                throw new ApplicationException($"Product could not be deleted");
            }
            else
            {
                var result = await _productRepository.Remove(product);
                return result;
            }
        }
    }
}
