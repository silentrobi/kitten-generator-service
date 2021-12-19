using KittenGeneratorService.Application.Features.Image.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KittenGeneratorService.Api.Controllers
{
    [Route("api/cat")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ImageGeneratorController : BaseApiController
    {

        /// <summary>
        /// Generates a cat image upside-down
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Return cat image upside-down</response>
        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GenerateVerticalFlippedCatImage()
        {
            var result = await Mediator.Send(new GenerateVerticalFlippedImage());

            return File(result, "image/jpeg");
        }
    }
}
