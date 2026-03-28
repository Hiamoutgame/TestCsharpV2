using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestRepo.Service.Category
{
    public class Service : IService
    {
        private readonly Repository.AppDbContext _dbContext;
        public Service(Repository.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> CreateCategoryAsync(string name, Guid? parentId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Category name cannot be null or empty.");
            }
            var nameExists = _dbContext.Categories.Any(c => c.Name == name);
            if (nameExists)
            {
                throw new InvalidOperationException("A category with the same name already exists.");
            }
            var category = new Repository.Entities.Category
            {
                Id = Guid.NewGuid(),
                Name = name,
                ParentId = parentId ?? Guid.Empty,
                CreatedAt = DateTimeOffset.UtcNow
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return "add category successfully";
        }

        public async Task<List<Response.GetAllCategories>> GetAllCategoriesAsync()
        {


            if (!_dbContext.Categories.Any())
            {
                throw new InvalidOperationException("No categories found.");
            }
            var categories = await _dbContext.Categories.OrderBy(c => c.Name).ToListAsync();

            var responseCategories = categories.Select(c => new Response.GetAllCategories
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return responseCategories;

        }

        public async Task<List<Response.GetAllChildCategories>> GetAllChildCategoriesAsync(Guid parentId)
        {
            var childCategories = await _dbContext.Categories.Where(c => c.ParentId == parentId).ToListAsync();

            if (!childCategories.Any())
            {
                throw new InvalidOperationException("No child categories found for the specified parent ID.");
            }

            var responseChildCategories = childCategories.Select(c => new Response.GetAllChildCategories
            {
                Id = c.Id,
                Name = c.Name,
            });

            return responseChildCategories.ToList();
        }
    }
}

