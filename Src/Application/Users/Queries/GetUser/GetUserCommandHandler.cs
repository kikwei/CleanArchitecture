using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Application.Common.Exceptions;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Users.Queries.GetUser
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, UserVm>
    {
        private readonly IProductsCleanArchDbContext _context;
        private readonly IMapper _mapper;

        public GetUserCommandHandler(IProductsCleanArchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserVm> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var vm = await _context.Users.ProjectTo<UserVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.UserId == request.Id, cancellationToken);
            if (vm == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return vm;
        }
    }
}