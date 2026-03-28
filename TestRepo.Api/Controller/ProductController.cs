using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestRepo.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Service.Product.IService _productService;
        public ProductController(Service.Product.IService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(string name, decimal price, Guid sellerId)
        {
            var result = await _productService.CreateProductAsync(name, price, sellerId);
            return Ok(result);
        }
    }
}