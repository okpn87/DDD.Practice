using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class UserUpdateCommand
    {
        public string Id { get; }
        public string Name { get; set; }
        public string MailAddress { get; set; }

        public UserUpdateCommand(string id)
        {
            Id = id;
        }
    }
}
