using MediatR;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}