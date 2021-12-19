using KittenGeneratorService.Application.Features.Image.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KittenGeneratorService.Api.Controllers
{
    [Route("api/cat/image")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ImageGeneratorController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GenerateVerticalFlippedCatImage()
        {
            var result = await Mediator.Send(new GenerateVerticalFlippedImage());

            return File(result, "image/jpeg");
        }
    }
}
