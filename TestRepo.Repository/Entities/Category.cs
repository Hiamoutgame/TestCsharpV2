using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRepo.Repository.Abstractions;

namespace TestRepo.Repository.Entities
{
    public class Category : BaseEntity<Guid>, IAuditableEntity
    {

        public Guid ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> Children { get; set; } = new List<Category>();
        public required string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

    }
}