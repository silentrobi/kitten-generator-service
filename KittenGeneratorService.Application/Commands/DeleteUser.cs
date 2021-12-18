using KittenGeneratorService.Application.SeedWork;
using System;

namespace KittenGeneratorService.Application.Commands
{
    public class DeleteUser : ICommand
    {
        public Guid Id { get; set; }
    }
}
