using Epam.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.BLL.Interfaces
{
    public interface IUserLogic
    {
        User AddUser(string name, string password, string email);

        User RemoveUser(int id);

        User EditUser(int id, string newName, string newPassword, string newEmail);

        IEnumerable<User> GetUsers(int id);

        bool AuthenticationUser(string name, string password);
    }
}
