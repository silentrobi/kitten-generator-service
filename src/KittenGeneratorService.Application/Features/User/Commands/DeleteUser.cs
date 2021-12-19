using KittenGeneratorService.Application.SeedWork;
using System;

namespace KittenGeneratorService.Application.Features.User.Commands
{
    public class DeleteUser : ICommand
    {
        public Guid Id { get; set; }
    }
}
