using KittenGeneratorService.Application.Features.User.Dtos;
using KittenGeneratorService.Application.SeedWork;

namespace KittenGeneratorService.Application.Features.User.Commands
{
    public class AuthenticateUser : ICommand<TokenDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
