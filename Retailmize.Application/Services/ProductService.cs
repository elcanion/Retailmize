using AutoMapper;
using MediatR;
using Retailmize.Application.DTOs;
using Retailmize.Application.Interfaces;
using Retailmize.Application.Products.Commands;
using Retailmize.Application.Products.Queries;
using Retailmize.Domain.Entities;
using Retailmize.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new Exception($"Products could not be loaded");

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
                throw new Exception($"Product could not be loaded");
            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productDeleteCommand = new ProductDeleteCommand(id.Value);
            if (productDeleteCommand == null)
                throw new Exception($"Product could not be loaded");
            await _mediator.Send(productDeleteCommand);
        }
    }
}
