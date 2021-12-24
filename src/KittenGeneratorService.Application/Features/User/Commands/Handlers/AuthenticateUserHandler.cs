using KittenGeneratorService.Application.Exceptions;
using KittenGeneratorService.Application.Features.User.Dtos;
using KittenGeneratorService.Application.Features.User.Repositories;
using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Application.Utils;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Features.User.Commands.Handlers
{
    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser, TokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticateUserHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<TokenDto> Handle(AuthenticateUser command, CancellationToken cancellationToken)
        {
            var user = _userRepository.FindByUsernameAndPassword(command.Username, command.Password);

            if (user == null)
            {
                throw new UserAuthenticationFailException("Invalid user credential");
            }

            Claim[] claims = {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("role", user.Role)
            };

            return new TokenDto()
            {
                Token = JwtUtil.GetJwtTokenString(_configuration["Jwt:Key"], user.Id.ToString(), claims)
            };
        }
    }
}
