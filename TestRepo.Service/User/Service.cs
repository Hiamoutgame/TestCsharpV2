using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestRepo.Service.User
{
    public class Service : IService
    {
        private readonly Repository.AppDbContext _dbContext;
        public Service(Repository.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateUserAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "Email and password cannot be empty.";
            }

            var user = new Repository.Entities.User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                Role = "User",
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return "add user successfully";
        }

        public async Task<Base.Response.PageResult<Response.GetAllUsers>> GetAllUsersAsync(string? searchTerm, int pageNumber, int pageSize)
        {
            var query = _dbContext.Users.Where(u => true);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(u => u.Email.Contains(searchTerm));
            }

            var totalItems = await query.CountAsync();
            var users = await query
                .OrderBy(u => u.Email)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var response = new Base.Response.PageResult<Response.GetAllUsers>
            {
                Items = users.Select(u => new Response.GetAllUsers
                {
                    Id = u.Id,
                    email = u.Email,
                    role = u.Role
                }).ToList(),
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return response;
        }
    }
}
