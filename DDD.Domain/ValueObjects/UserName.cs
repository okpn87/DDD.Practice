using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public class UserName
    {
        public string Value { get; }

        public UserName(string value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if(value.Length < 3)
            {
                throw new ArgumentException("ユーザー名は３文字以上です。　", nameof(value));
            }
            if(value.Length > 20)
            {
                throw new ArgumentException("ユーザー名は２０文字以下です。　", nameof(value));
            }

            Value = value;
        }
    }
}
