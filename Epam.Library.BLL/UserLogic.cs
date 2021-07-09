using Epam.Library.BLL.Interfaces;
using Epam.Library.Common.Entities;
using Epam.Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.BLL.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDAO _userDAO;
        public UserLogic(IUserDAO userDAO) =>
            _userDAO = userDAO;
        public User AddUser(string name, string password, string email) =>
            _userDAO.AddUser(name, password, email);

        public User RemoveUser(int id) =>
            _userDAO.RemoveUser(id);
        public void RemoveUser(User book) => RemoveUser(book.Id);

        public User EditUser(int id, string newName, string newPassword, string newEmail) =>
            _userDAO.EditUser(id, newName, newPassword, newEmail);
        public User GetUserInfo(string name) =>
            _userDAO.GetUserInfo(name);

        public bool AuthenticationUser(string name, string password) =>
            _userDAO.AuthenticationUser(name, password);
    }
}
