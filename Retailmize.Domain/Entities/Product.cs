using Retailmize.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Product Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            Validate(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID");
            Id = id;
            Validate(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            Validate(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void Validate(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name required");
            DomainExceptionValidation.When(name.Length < 3,
                $"Invalid name \"{name}\". The name must have at least 3 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description required");
            DomainExceptionValidation.When(description.Length < 5,
                $"Invalid description \"{description}\". The description must have at least 5 characters.");
            DomainExceptionValidation.When(price < 0, "Invalid price");
            DomainExceptionValidation.When(stock < 0, "Invalid stock");
            DomainExceptionValidation.When(image?.Length > 250,
                $"Invalid image name. The image name must have a maximum of 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
