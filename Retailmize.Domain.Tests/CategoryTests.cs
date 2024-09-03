using FluentAssertions;
using Retailmize.Domain.Entities;
using System;
using System.Xml.Linq;
using Xunit;

namespace Retailmize.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultValidStateObject()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<Retailmize.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_ResultInvalidIdDomainException()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid ID");
        }

        [Fact]
        public void CreateCategory_EmptyNameValue_ResultEmptyNameDomainException()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name \"\".");
        }

        [Fact]
        public void CreateCategory_NullNameValue_ResultNullNameDomainException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name \"\".");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_ResultShortNameDomainException()
        {
            Action action = () => new Category(1, "C");
            action.Should()
                .Throw<Retailmize.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name \"C\". The name must have at least 3 characters.");
        }
    }
}
