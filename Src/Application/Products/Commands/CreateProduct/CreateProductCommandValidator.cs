using FluentValidation;

namespace ProductsCleanArch.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductName).Length(2, 50);
            RuleFor(x => x.UnitPrice).NotEmpty();
        }
    }
}