using DDD.Domain.Entites;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infrastructure.Fake
{
    public class InMemoryUserRepository : IUserRepository
    {
        // テストケースによってはデータを確認したいことがある
        // 確認のための操作を外部から行えるようにするためpublicにしている
        public Dictionary<UserId, User> Store { get; } = new Dictionary<UserId, User>();

        /// <summary>
        /// IDによるユーザー検索
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User FindById(UserId userId)
        {
            var target = Store.Values.FirstOrDefault(user => userId.Equals(user.Id));

            if (target != null)
            {
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ユーザー名によるユーザー検索
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User FindByName(UserName userName)
        {
            var target = Store.Values.FirstOrDefault(user => userName.Equals(user.Name));

            if(target != null)
            {
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// メールアドレスによるユーザー検索
        /// </summary>
        /// <param name="mailAddress"></param>
        /// <returns></returns>
        public User FindByMailAddress(MailAddress mailAddress)
        {
            var target = Store.Values.FirstOrDefault(user => mailAddress.Equals(user.MailAddress));

            if (target != null)
            {
                return Clone(target);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ユーザー保存
        /// </summary>
        /// <param name="user"></param>
        public void Save(User user)
        {
            // 保存時もディープコピーを行う
            Store[user.Id] = Clone(user);
        }

        /// <summary>
        /// ユーザー削除
        /// </summary>
        /// <param name="user"></param>
        public void Delete(User user)
        {
            _ = Store.Remove(user.Id);
        }

        /// <summary>
        /// ディープコピーを行うメソッド
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private User Clone(User user)
        {
            return new User(user.Id, user.Name, user.MailAddress);
        }
    }
}
