using DDD.Domain.Entites;
using DDD.Domain.Exceptions;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    public class Circle
    {
        private readonly CircleId id;
        public CircleName Name { get; private set; }
        private User owner;
        private List<User> members;

        public Circle(CircleId id, CircleName name, User owner, List<User> members)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (members == null) throw new ArgumentNullException(nameof(members));

            this.id = id;
            Name = name;
            this.owner = owner;
            this.members = members;
        }

        public bool IsFull()
        {
            return this.members.Count >= 29;
        }

        public void Join(User member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));

            if(this.IsFull())
            {
                throw new CircleFullException(this.id);
            }

            this.members.Add(member);
        }
    }
}
