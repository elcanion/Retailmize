using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retailmize.Application.DTOs;
using Retailmize.Application.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retailmize.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetAll();
            if (categories == null)
            {
                return NotFound("Couldn't find categories");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Couldn't find category");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest("Invalid category");

            await _categoryService.Add(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new {id = categoryDTO.Id}, categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
                return BadRequest();

            if (categoryDTO == null)
                return BadRequest();

            await _categoryService.Update(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound("Category not found");

            await _categoryService.Remove(id);
            return Ok(category);
        }
    }
}
