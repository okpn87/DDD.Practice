using DDD.Domain.Entites;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// IDによるユーザー検索
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User FindById(UserId id);
        /// <summary>
        /// ユーザー名によるユーザー検索
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User FindByName(UserName name);
        /// <summary>
        /// メールアドレスによるユーザー検索
        /// </summary>
        /// <param name="mailAddress"></param>
        /// <returns></returns>
        User FindByMailAddress(MailAddress mailAddress);
        /// <summary>
        /// ユーザー保存
        /// </summary>
        /// <param name="user"></param>
        void Save(User user);
        /// <summary>
        /// ユーザー削除
        /// </summary>
        /// <param name="user"></param>
        void Delete(User user);
    }
}
