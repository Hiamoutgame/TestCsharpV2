using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestRepo.Api.Extensions;
using TestRepo.Service.User;

namespace TestRepo.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IService _UserService;
        public UserController(IService userService)
        {
            _UserService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(string email, string password)
        {
            var result = await _UserService.CreateUserAsync(email, password);
            return Ok(result);
        }


        [HttpGet]
        [Authorize(Policy = JwtExtensions.AdminPolicy)]
        public async Task<IActionResult> GetAllUsers(string? searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _UserService.GetAllUsersAsync(searchTerm, pageNumber, pageSize);
            return Ok(result);
        }

    }
}