using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Commands
{
    public class UpdateUser : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
