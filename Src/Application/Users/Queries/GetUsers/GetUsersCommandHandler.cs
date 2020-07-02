using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Application.Common.Interfaces;

namespace ProductsCleanArch.Application.Users.Queries.GetUsers
{
    public class GetUsersCommandHandler : IRequestHandler<GetUsersCommand, UsersListVm>
    {
        private readonly IProductsCleanArchDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersCommandHandler(IProductsCleanArchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UsersListVm> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).OrderBy(u => u.UserId).ToListAsync(cancellationToken);
            var vm = new UsersListVm
            {
                Users = users
            };

            return vm;
        }
    }
}