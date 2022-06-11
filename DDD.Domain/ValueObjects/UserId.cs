using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public class UserId
    {
        public string Value { get; }

        public UserId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("valueがnullまたは空文字です");
            }

            Value = value;
        }
    }
}
