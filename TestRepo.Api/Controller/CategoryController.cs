using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.Category;


namespace TestRepo.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IService _CategoryService;
        public CategoryController(IService categoryService)
        {
            _CategoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] string name, Guid? parentId)
        {
            var result = await _CategoryService.CreateCategoryAsync(name, parentId);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _CategoryService.GetAllCategoriesAsync();
            return Ok(result);
        }
        [HttpGet("{parentId}/children")]
        public async Task<IActionResult> GetAllChildCategories(Guid parentId)
        {
            var result = await _CategoryService.GetAllChildCategoriesAsync(parentId);
            return Ok(result);
        }
    }
}