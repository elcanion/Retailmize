using MediatR;
using Retailmize.Application.Products.Queries;
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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(query.Id);
        }
    }
}
