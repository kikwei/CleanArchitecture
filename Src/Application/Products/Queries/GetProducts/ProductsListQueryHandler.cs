using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Application.Common.Interfaces;

namespace ProductsCleanArch.Application.Products.Queries.GetProducts
{
    public class ProductsListQueryHandler : IRequestHandler<GetProductsCommand, ProductsListVm>
    {
        private readonly IProductsCleanArchDbContext _context;
        private readonly IMapper _mapper;

        public ProductsListQueryHandler(IProductsCleanArchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductsListVm> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).OrderBy(p => p.ProductId).ToListAsync(cancellationToken);

            var vm = new ProductsListVm
            {
                Products = products
            };

            return vm;
        }
    }
}