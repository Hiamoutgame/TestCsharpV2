using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.Auth
{
    public interface IService
    {
        public Task<Response.Login> Login(string email, string password);
    }
}