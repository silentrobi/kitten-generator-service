using System;

namespace KittenGeneratorService.Application.Exceptions
{
    public class UserAuthenticationFailException : Exception
    {
        public UserAuthenticationFailException()
        {
        }

        public UserAuthenticationFailException(string message) : base(message)
        {
        }
    }
}
