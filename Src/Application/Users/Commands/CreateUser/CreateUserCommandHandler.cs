using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IProductsCleanArchDbContext _context;

        public CreateUserCommandHandler(IProductsCleanArchDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FullName = request.FullName,
                Occupation = request.Occupation,
                Age = request.Age,
                Email = request.Email,
                UserName = request.Email.Split("@")[0]
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}