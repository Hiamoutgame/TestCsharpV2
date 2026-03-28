using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.Product
{
    public interface IService
    {
        public Task<string> CreateProductAsync(string name, decimal price, Guid sellerId);

    }
}