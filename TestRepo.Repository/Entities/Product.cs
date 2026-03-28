using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRepo.Repository.Abstractions;

namespace TestRepo.Repository.Entities
{
    public class Product : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; }

        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}