using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositories
{
    public interface ICircleRepository
    {
        void Save(Circle circle);
        Circle FindById(CircleId id);
        Circle FineByName(CircleName name);
    }
}
