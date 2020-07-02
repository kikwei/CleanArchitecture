using MediatR;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }
    }
}