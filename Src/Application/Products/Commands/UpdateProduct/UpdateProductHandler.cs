using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductsCleanArch.Application.Common.Exceptions;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductsCleanArchDbContext _context;

        public UpdateProductHandler(IProductsCleanArchDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.ProductId = request.ProductId;
            entity.ProductName = request.ProductName;
            entity.UnitPrice = request.UnitPrice;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}