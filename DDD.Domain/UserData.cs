using DDD.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class UserData
    {
        public string Id { get; }
        public string Name { get; }
        public string MailAddress { get; }

        public UserData(User source)
        {
            Id = source.Id.Value;
            Name = source.Name.Value;
            MailAddress = source.MailAddress.Value;
        }
    }
}
