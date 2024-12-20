using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Exceptions.MiddlewareExceptions
{
  
    public class TooManyRequestException : Exception
    {
        public TooManyRequestException()
        {
        }
        public TooManyRequestException(string message) : base(message)
        {
        }
        public TooManyRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
