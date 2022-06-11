using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    public class CircleFullException : Exception
    {
        public CircleFullException()
        {
        }

        public CircleFullException(string message) : base(message)
        {
        }

        public CircleFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CircleFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CircleFullException(CircleId id)
        {

        }
    }
}
