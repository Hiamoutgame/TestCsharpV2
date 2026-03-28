using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.Base
{
    public class Response
    {
        public class PageResult<T>
        {
            public List<T> Items { get; set; } = new List<T>();
            public int TotalItems { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }
    }
}