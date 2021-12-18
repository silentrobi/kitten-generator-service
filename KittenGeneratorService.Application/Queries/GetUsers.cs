using KittenGeneratorService.Application.Dtos;
using KittenGeneratorService.Application.SeedWork;
using System.Collections.Generic;

namespace KittenGeneratorService.Application.Queries
{
    public class GetUsers : IQuery<IEnumerable<UserDto>>
    {
    }
}
