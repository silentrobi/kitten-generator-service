using KittenGeneratorService.Application.Dtos;
using KittenGeneratorService.Application.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Commands
{
    public class AuthenticateUser : ICommand<TokenDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
