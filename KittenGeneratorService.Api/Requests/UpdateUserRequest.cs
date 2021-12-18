using KittenGeneratorService.Domain.ValueObjects;

namespace KittenGeneratorService.Api.Requests
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
