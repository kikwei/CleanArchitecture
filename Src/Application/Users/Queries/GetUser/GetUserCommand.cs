using MediatR;

namespace ProductsCleanArch.Application.Users.Queries.GetUser
{
    public class GetUserCommand : IRequest<UserVm>
    {
        public int Id { get; set; }
    }
}