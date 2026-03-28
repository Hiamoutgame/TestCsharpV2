using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRepo.Repository.Abstractions;

namespace TestRepo.Repository.Entities
{
    public class Seller : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public required string TaxCode { get; set; }
        public required string CompanyName { get; set; }
        public required string CompanyAddress { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}