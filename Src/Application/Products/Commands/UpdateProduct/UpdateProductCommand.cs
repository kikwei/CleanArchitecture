using MediatR;

namespace ProductsCleanArch.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
    }
}