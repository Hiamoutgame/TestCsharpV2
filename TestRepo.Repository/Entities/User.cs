using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRepo.Repository.Abstractions;

namespace TestRepo.Repository.Entities
{
    public class User : BaseEntity<Guid>, IAuditableEntity
    {

        public required string Role { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public Seller? Seller { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}