using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Exceptions.MiddlewareExceptions;

public class InvalidResponseException : Exception
{
    public InvalidResponseException()
    {
    }
    public InvalidResponseException(string message) : base(message)
    {
    }
    public InvalidResponseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
