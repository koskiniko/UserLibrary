using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserLibrary.Application.Common.Exceptions;
using UserLibrary.Application.Users;
using UserLibrary.Application.Users.Commands;
using UserLibrary.Application.Users.Queries;

namespace UserLibrary.API.Controllers
{
    /// <summary>
    /// User-related CRUD-operations
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender"></param>
        public UserController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        [HttpPost]
        public async Task Create(CreateNewUserCommand command)
        {
            await _sender.Send(command);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _sender.Send(new DeleteUserCommand() { Id = id });
        }

        /// <summary>
        /// Return all users
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _sender.Send(new GetAllUsersQuery());
        }

        /// <summary>
        /// Return all users
        /// </summary>
        [HttpGet("search")]
        public async Task<IEnumerable<UserDto>> Search([FromQuery] string name)
        {
            return await _sender.Send(new GetAllUsersQuery() { NameMustContain = name });
        }

        /// <summary>
        /// Update user info
        /// </summary>
        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateUserCommand command)
        {
            await _sender.Send(command with { Id = id });
        }
    }
}