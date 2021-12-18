using KittenGeneratorService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
