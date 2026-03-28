using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.User
{
    public class Response
    {
        public class GetAllUsers
        {
            public Guid Id { get; set; }
            public string email { get; set; }
            public string role { get; set; }
        }

    }
}