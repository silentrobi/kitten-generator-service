using KittenGeneratorService.Application.Dtos;
using KittenGeneratorService.Application.Repositories;
using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Application.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Commands.Handlers
{
    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser, TokenDto>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<TokenDto> Handle(AuthenticateUser command, CancellationToken cancellationToken)
        {
            var user = _userRepository.FindByUsernameAndPassword(command.Username, command.Password);

            if (user == null)
            {
                // throw expetion
            }

            Claim[] claims = {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("role", user.Role)
            };

            return new TokenDto()
            {
                Token = JwtUtil.GetJwtTokenString(user.Id.ToString(), claims)
            };
        }
    }
}
