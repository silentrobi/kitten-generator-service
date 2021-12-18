using KittenGeneratorService.Application.SeedWork;
using System;

namespace KittenGeneratorService.Application.Commands
{
    public class UpdateUser : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
