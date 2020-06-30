using MediatR;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
    }
}