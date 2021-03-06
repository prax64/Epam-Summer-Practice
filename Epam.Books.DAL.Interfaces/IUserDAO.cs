using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.Common.Entities;

namespace Epam.Library.DAL.Interfaces
{
    public interface IUserDAO
    {
        User AddUser(string name, string password, string email);

        User RemoveUser(int id);

        User EditUser(int id, string newName, string newPassword, string newEmail);

        User GetUserInfo(string name);

        bool AuthenticationUser(string name, string password);

    }
}
