using DDD.Domain.Entites;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.DomainService
{
    /// <summary>
    /// ユーザー関連のドメインサービス
    /// </summary>
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// メールアドレスによる重複確認
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Exists(User user)
        {
            var dublicatedUser = userRepository.FindByMailAddress(user.MailAddress);

            return dublicatedUser != null;
        }
    }
}
