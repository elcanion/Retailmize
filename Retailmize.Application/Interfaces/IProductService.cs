﻿using Retailmize.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(int? id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int? id);
    }
}
