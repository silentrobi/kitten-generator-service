using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;

namespace KittenGeneratorService.Api.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
        protected Claim[] User => HttpContext.User.Claims.Select(x => x).ToArray();
    }
}
