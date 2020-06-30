using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductsCleanArchDbContext _context;

        public CreateProductCommandHandler(IProductsCleanArchDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                UnitPrice = request.UnitPrice,
                ProductName = request.ProductName
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }
    }
}