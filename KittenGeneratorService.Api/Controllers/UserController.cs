using KittenGeneratorService.Application.Commands;
using KittenGeneratorService.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create(CreateUser request)
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
    }
}
