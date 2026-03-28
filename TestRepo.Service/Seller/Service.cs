using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestRepo.Service.Seller
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

        public async Task<string> CreateSellerAsync(string email, string password, string taxCode, string companyName, string companyAddress, string role = "Seller")
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(taxCode) || string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(companyAddress))
            {
                return "All fields are required.";
            }

            var user = new Repository.Entities.User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                Role = role,

            };
            var seller = new Repository.Entities.Seller
            {
                Id = Guid.NewGuid(),
                TaxCode = taxCode,
                CompanyName = companyName,
                CompanyAddress = companyAddress,
                User = user
            };

            _dbContext.Sellers.Add(seller);
            await _dbContext.SaveChangesAsync();

            return "add seller successfully";
        }
    }
}
