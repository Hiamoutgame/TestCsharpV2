using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestRepo.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly Service.Seller.IService _sellerService;
        public SellerController(Service.Seller.IService sellerService)
        {
            _sellerService = sellerService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeller(string email, string password, string taxCode, string companyName, string companyAddress)
        {
            var result = await _sellerService.CreateSellerAsync(email, password, taxCode, companyName, companyAddress);
            return Ok(result);
        }
    }
}