using System.Collections.Generic;

namespace ProductsCleanArch.Application.Users.Queries.GetUsers
{
    public class UsersListVm
    {
        public IList<UserDto> Users { get; set; }
    }
}