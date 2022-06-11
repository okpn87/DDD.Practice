using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base()
        {

        }

        public UserNotFoundException(string message) : base(message)
        {

        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public UserNotFoundException(UserId userId)
        {

        }
    }
}
