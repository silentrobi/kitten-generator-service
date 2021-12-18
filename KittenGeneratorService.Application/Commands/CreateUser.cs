using KittenGeneratorService.Application.SeedWork;
using System;

namespace KittenGeneratorService.Application.Commands
{
    public class CreateUser : ICommand<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
    }
}
