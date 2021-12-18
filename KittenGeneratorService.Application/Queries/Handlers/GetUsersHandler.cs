using KittenGeneratorService.Application.Dtos;
using KittenGeneratorService.Application.Repositories;
using KittenGeneratorService.Application.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Queries.Handlers
{
    public class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsers query, CancellationToken cancellationToken)
        {
            return _userRepository.Get().Select(x => new UserDto {
                Id = x.Id,
                Email = x.Email,
                Username = x.Username,
                Role = x.Role,
                CreatedDate = x.CreatedDate
            });
        }
    }
}
