using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.User
{
    public interface IService
    {
        public Task<string> CreateUserAsync(string email, string password);
        public Task<Base.Response.PageResult<Response.GetAllUsers>> GetAllUsersAsync(string? searchTerm, int pageNumber, int pageSize);
    }
}