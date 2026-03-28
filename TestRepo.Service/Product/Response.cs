using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepo.Service.Product
{
    public class Response
    {
        public class CreateProduct
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public Guid SellerId { get; set; }
        }
    }
}