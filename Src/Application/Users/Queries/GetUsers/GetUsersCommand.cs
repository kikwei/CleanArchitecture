using MediatR;

namespace ProductsCleanArch.Application.Users.Queries.GetUsers
{
    public class GetUsersCommand : IRequest<UsersListVm> { }
}