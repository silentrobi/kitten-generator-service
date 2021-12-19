using KittenGeneratorService.Api.Requests;
using KittenGeneratorService.Application.Features.User.Commands;
using KittenGeneratorService.Application.Features.User.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KittenGeneratorService.Api.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUser request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// get users
        /// </summary>
        /// <response code="200">Returns list of users</response>
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetUsers());

            return Ok(result);
        }

        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUserRequest"></param>
        /// <returns></returns>
        /// <response code="200">Updates existing user</response>
        /// <response code="400">If user not found</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            var updateUser = new UpdateUser()
            {
                Id = id,
                Password = updateUserRequest.Password,
                Role = updateUserRequest.Role,
                Username = updateUserRequest.Username
            };

            var result = await Mediator.Send(updateUser);

            return Ok(result);
        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">User is deleted</response>
        /// <response code="400">If user not found</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
           await Mediator.Send(new DeleteUser() { Id= id});

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateUser authenticateUser)
        {
            var result = await Mediator.Send(authenticateUser);

            return Ok(result);
        }
    }
}
