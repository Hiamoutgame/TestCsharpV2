using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.Seller
{
    public interface IService
    {
        public Task<string> CreateSellerAsync(string email, string password, string taxCode, string companyName, string companyAddress, string role = "Seller");
    }
}