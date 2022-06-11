using DDD.Domain.Entites;
using DDD.Domain.Factories;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Implements
{
    public class UserFactory : IUserFactory
    {
        public User Create(UserName name, MailAddress mailAddress)
        {
            string seqId;

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT seq = (NEXT VALUE FOR UserSeq)";
                using(var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var rawSeqId = reader["seq"];
                        seqId = rawSeqId.ToString();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            var id = new UserId(seqId);
            return new User(id, name, mailAddress);
        }
    }
}
