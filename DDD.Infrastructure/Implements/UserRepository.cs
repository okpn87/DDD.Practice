using DDD.Domain.Entites;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DDD.Infrastructure.Implements
{
    public class UserRepository : IUserRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// IDによるユーザー検索
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User FindById(UserId userId)
        {
            using (var connection = new SqlConnection(connectionString))
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", userId.Value));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var id = reader["id"] as string;
                        var name = reader["name"] as string;
                        var mailAddress = reader["mailAddress"] as string;

                        return new User(
                            new UserId(id),
                            new UserName(name),
                            new MailAddress(mailAddress));
                    }
                    else
                    {
                        return null;
                    }
                }
            }

                throw new NotImplementedException();
        }

        /// <summary>
        /// ユーザー名によるユーザー検索
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User FindByName(UserName userName)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE name = @name";
                command.Parameters.Add(new SqlParameter("@name", userName.Value));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var id = reader["id"] as string;
                        var name = reader["name"] as string;
                        var mailAddress = reader["mailAddress"] as string;

                        return new User(
                            new UserId(id),
                            new UserName(name),
                            new MailAddress(mailAddress));
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// メールアドレスによるユーザー検索
        /// </summary>
        /// <param name="mailAddress"></param>
        /// <returns></returns>
        public User FindByMailAddress(MailAddress mailAddress)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"
MERGE INTO users
  USING (
    SELECT @id AS id, @name AS name
  ) AS data
  ON users.id = data.id
  WHEN MATCHED THEN
    UPDATE SET name = data.name
  WHEN NO MATCHED THEN
    INSERT (id, name)
    VALUES (data.id, data.name);
";
                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));
                command.ExecuteNonQuery();
            }
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
