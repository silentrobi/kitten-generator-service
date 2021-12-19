using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Exceptions
{
    public class ExternalServiceException : Exception
    {
        public ExternalServiceException()
        {
        }

        public ExternalServiceException(string message) : base(message)
        {
        }
    }
}
