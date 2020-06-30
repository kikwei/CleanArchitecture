using MediatR;

namespace ProductsCleanArch.Application.Products.Queries.GetProduct
{
    public class GetProductCommand : IRequest<ProductVm>
    {
        public int Id { get; set; }
    }
}