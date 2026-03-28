using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestRepo.Service.Product
{
    public class Service : IService
    {
        private readonly Repository.AppDbContext _dbContext;
        public Service(Repository.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateProductAsync(string name, decimal price, Guid sellerId)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || sellerId == Guid.Empty)
            {
                throw new ArgumentException("Invalid input parameters");
            }
            var product = new Repository.Entities.Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                SellerId = sellerId
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return "add product successfully";
        }
    }
}

