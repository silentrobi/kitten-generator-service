using KittenGeneratorService.Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations;

namespace KittenGeneratorService.Domain.Entities
{
    public class User : BaseEntity
    {
        private User()
        {

        }
        private User(string userName, string password, string email, string role)
        {
            Id = Guid.NewGuid();
            Username = userName;
            Password = password;
            Email = email;
            Role = role;
        }
        public static User Create(string userName, string password, string email, string role)
        {
            return  new User(userName, password, email, role);
        }

        public void Update(string username, string password, string role)
        {
            Username = username;
            Role = role;
            Password = password;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string  Role { get; set; }
    }
}
