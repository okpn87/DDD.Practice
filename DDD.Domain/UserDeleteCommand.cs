using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class UserDeleteCommand
    {
        public string Id { get; }

        public UserDeleteCommand(string id)
        {
            Id = id;
        }
    }
}
