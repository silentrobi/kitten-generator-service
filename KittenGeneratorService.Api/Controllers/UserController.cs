using KittenGeneratorService.Api.Requests;
using KittenGeneratorService.Application.Commands;
using KittenGeneratorService.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KittenGeneratorService.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Create a new department
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUser request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetUsers());

            return Ok(result);
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           await Mediator.Send(new DeleteUser() { Id= id});

            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateUser authenticateUser)
        {
            var result = await Mediator.Send(authenticateUser);

            return Ok(result);
        }
    }
}
