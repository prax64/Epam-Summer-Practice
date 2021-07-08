using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Labrary.Entities
{
    class User
    {
        public User(int id, string name, string password, string email)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }
    }
}
