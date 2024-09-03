using Retailmize.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            Validate(name);  
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID");
            Id = id;

            Validate(name);
        }

        private void Validate(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                $"Invalid name \"{name}\".");

            DomainExceptionValidation.When(name.Length < 3,
                $"Invalid name \"{name}\". The name must have at least 3 characters.");

            Name = name;
        }

        public void Update(string name)
        {
            Validate(name);
        }
    }
}
