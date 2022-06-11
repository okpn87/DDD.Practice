using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entites
{
    /// <summary>
    /// ユーザー
    /// </summary>
    public class User : IEquatable<User>
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        public UserId Id { get; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        public UserName Name { get; private set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public MailAddress MailAddress { get; private set; }

        /// <summary>
        /// コンストラクタ（インスタンスを新たに生成する際に利用）
        /// </summary>
        /// <param name="name">ユーザー名</param>
        public User(UserName name, MailAddress mailAddress)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if(mailAddress == null)
            {
                throw new ArgumentException(nameof(mailAddress));
            }

            Id = new UserId(Guid.NewGuid().ToString());
            Name = name;
            MailAddress = mailAddress;
        }

        /// <summary>
        /// コンストラクタ（インスタンスを再構築する際に利用）
        /// </summary>
        /// <param name="id">ユーザーID</param>
        /// <param name="name">ユーザー名</param>
        public User(UserId id, UserName name, MailAddress mailAddress)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Id = id;
            Name = name;
            MailAddress = mailAddress;
        }

        /// <summary>
        /// 同一オブジェクト比較メソッド
        /// </summary>
        /// <param name="other">比較対象</param>
        /// <returns>比較結果</returns>
        public bool Equals(User other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(this.Id, other.Id);   // 比較はID同士で行う
        }

        /// <summary>
        /// 同一オブジェクト比較メソッド（override）
        /// </summary>
        /// <param name="obj">比較対象</param>
        /// <returns>比較結果</returns>
        public override bool Equals(object obj)
        {
            if(obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((User) obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void ChangeUserName(UserName userName)
        {
            this.Name = userName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailAddress"></param>
        public void ChangeMailAddress(MailAddress mailAddress)
        {
            this.MailAddress = mailAddress;
        }
    }
}
