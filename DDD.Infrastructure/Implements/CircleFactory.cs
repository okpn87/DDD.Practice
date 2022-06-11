using DDD.Domain.Entites;
using DDD.Domain.Entities;
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
    public class CircleFactory : ICircleFactory
    {
        public Circle Create(CircleName name, User owner, List<User> members)
        {
            string seqId;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT seq = (NEXT VALUE FOR CircleSeq)";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        seqId = reader["seq"].ToString();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            var id = new CircleId(seqId);
            return new Circle(id, name, owner, members);
        }
    }
}
