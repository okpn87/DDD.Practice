using DDD.Domain.Entites;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Factories
{
    public interface IUserFactory
    {
        User Create(UserName name, MailAddress mailAddress);
    }
}
