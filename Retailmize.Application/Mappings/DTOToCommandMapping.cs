using AutoMapper;
using Retailmize.Application.DTOs;
using Retailmize.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Application.Mappings
{
    public class DTOToCommandMapping : Profile
    {
        public DTOToCommandMapping()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
