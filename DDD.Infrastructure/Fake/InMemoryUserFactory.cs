using DDD.Domain.Entites;
using DDD.Domain.Factories;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Fake
{
    public class InMemoryUserFactory : IUserFactory
    {
        // 現在のID
        private int currentId;

        public User Create(UserName name, MailAddress mailAddress)
        {
            // ユーザーのインスタンスが生成されるたびにインクリメントする
            currentId++;

            return new User(new UserId(currentId.ToString()), name, mailAddress);
        }
    }
}
