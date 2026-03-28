using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.Category
{
    public class Response
    {
        public class GetAllCategories
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

        }
        public class GetAllChildCategories
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}