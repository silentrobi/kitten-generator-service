using KittenGeneratorService.Application.Features.User.Dtos;
using KittenGeneratorService.Application.SeedWork;
using System.Collections.Generic;

namespace KittenGeneratorService.Application.Features.User.Queries
{
    public class GetUsers : IQuery<IEnumerable<UserDto>>
    {
    }
}
