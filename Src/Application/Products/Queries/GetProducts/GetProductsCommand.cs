using MediatR;

namespace ProductsCleanArch.Application.Products.Queries.GetProducts
{
    public class GetProductsCommand : IRequest<ProductsListVm> { }
}