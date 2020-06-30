using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Application.Common.Exceptions;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, ProductVm>
    {
        private readonly IProductsCleanArchDbContext _context;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductsCleanArchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductVm> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var vm = await _context.Products.ProjectTo<ProductVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(p => p.ProductId == request.Id, cancellationToken);

            if (vm == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return vm;
        }
    }
}