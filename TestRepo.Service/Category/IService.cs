using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.Category
{
    public interface IService
    {
        public Task<string> CreateCategoryAsync(string name, Guid? parentId);
        public Task<List<Response.GetAllCategories>> GetAllCategoriesAsync();
        public Task<List<Response.GetAllChildCategories>> GetAllChildCategoriesAsync(Guid parentId);
    }
}