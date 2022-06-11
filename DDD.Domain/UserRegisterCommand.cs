using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class UserRegisterCommand
    {
        public string Name { get; }
        public string MailAddress { get; }

        public UserRegisterCommand(string name, string mailAddress)
        {
            Name = name;
            MailAddress = mailAddress;
        }
    }
}
