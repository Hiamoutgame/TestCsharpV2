using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestRepo.Service.Auth
{
    public class Service : IService
    {
        private readonly Repository.AppDbContext _dbContext;
        private readonly JwtService.IService _jwtService;
        private readonly JwtService.JwtOptions _jwtOptions = new();
        public Service(Repository.AppDbContext dbContext, JwtService.IService jwtService, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
            configuration.GetSection(nameof(JwtService.JwtOptions)).Bind(_jwtOptions);
        }

        public async Task<Response.Login> Login(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid email or password.");
            }

            // Here you would typically generate a JWT token
            // For now, we'll just return a simple response
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var token = _jwtService.GenerateAccessToken(claims);

            return new Response.Login { AccessToken = token };
        }
    }
}
