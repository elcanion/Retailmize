using FluentAssertions;
using Retailmize.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Retailmize.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultValidStateObject()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, "image.png");
            action.Should()
                .NotThrow<Retailmize.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NullNameValue_ResultNullNameDomainException()
        {
            Action action = () => new Product(1, null, "Product Description", 1, 1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name required");
        }

        [Fact]
        public void CreateProduct_EmptyNameValue_ResultEmptyNameDomainException()
        {
            Action action = () => new Product(1, "", "Product Description", 1, 1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name required");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_ResultShortNameDomainException()
        {
            Action action = () => new Product(1, "P", "Product Description", 1, 1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name \"P\". The name must have at least 3 characters.");
        }

        [Fact]
        public void CreateProduct_NullDescriptionValue_ResultNullDescriptionDomainException()
        {
            Action action = () => new Product(1, "Product Name", null, 1, 1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Description required");
        }

        [Fact]
        public void CreateProduct_EmptyDescriptionValue_ResultEmptyDescriptionDomainException()
        {
            Action action = () => new Product(1, "Product Name", "", 1, 1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Description required");
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_ResultShortDescriptionDomainException()
        {
            Action action = () => new Product(1, "Product Name", "P", 1, 1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description \"P\". The description must have at least 5 characters.");
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_ResultInvalidPriceDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1, 1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price");
        }

        [Fact]
        public void CreateProduct_InvalidStockValue_ResultInvalidStockDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, -1, "image.png");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock");
        }

        [Fact]
        public void CreateProduct_LargeImageNameValue_ResultLargeImageNameDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, "zephyrinocryptaxolythmandelbrinsyloperdifaxquixocorneliventorixalorumpendaglorathasmitraxosynvanderlinophylixorothimbracindomorphlaxotessandorimianthropelosynthanopoulafrixorimanderdonixyflamderingolyphryxvanderloquimthozalonfilormendacrominxpyrocheese");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. The image name must have a maximum of 250 characters.");
        }

        [Fact]
        public void CreateProduct_NullImageNameValue_ResultNoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, null);
            action.Should()
                .NotThrow<Retailmize.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NullImageNameValue_ResultNoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
