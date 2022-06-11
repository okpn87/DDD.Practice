using DDD.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    public class CanNotRegisterUserException : Exception
    {

        public CanNotRegisterUserException(User user, string message) : base(message)
        {
        }
    }
}
