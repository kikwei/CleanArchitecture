using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCleanArch.Application.Users.Commands.CreateUser;
using ProductsCleanArch.Application.Users.Commands.DeleteUser;
using ProductsCleanArch.Application.Users.Commands.UpdateUser;
using ProductsCleanArch.Application.Users.Queries.GetUser;
using ProductsCleanArch.Application.Users.Queries.GetUsers;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Presentation.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        [HttpGet]
        [Route("api/v1/users/get-users")]
        [DisplayName("Can Get Users Listing")]
        public async Task<ActionResult<UsersListVm>> GetUsers()
        {
            var vm = await Mediator.Send(new GetUsersCommand());
            return base.Ok(vm);
        }

        [HttpGet]
        [Route("api/v1/users/get-user/{id}")]
        [DisplayName("Can Get Single User")]
        public async Task<ActionResult<UserVm>> GetUser(int id)
        {
            var user = await Mediator.Send(new GetUserCommand { Id = id });
            return base.Ok(user);
        }

        [HttpPost]
        [Route("api/v1/users/create-user")]
        [DisplayName("Can Create User")]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserCommand command)
        {
            var user = await Mediator.Send(command);
            return Ok(user);
        }

        [HttpPut]
        [Route("api/v1/users/update-user")]
        [DisplayName("Can Update User")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("api/v1/users/delete-user/{id}")]
        [DisplayName("Can Delete User")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }
    }
}