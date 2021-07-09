using Epam.Library.Common.Entities;
using Epam.Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.DAL.SqlDAL
{
    public class UserSqlDAO : IUserDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public User AddUser(string name, string password, string email)
        {
            throw new NotImplementedException();
        }

        public User EditUser(int id, string newName, string newPassword, string newEmail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers(int id)
        {
            throw new NotImplementedException();
        }

        public User RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticationUser(string name, string password)
        {
            using (_connection)
            {
                var stProc = "User_Authentication";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@Name", name);
                comnand.Parameters.AddWithValue("@Password", password);

                _connection.Open();

                var resuilt = comnand.ExecuteScalar();

                if (resuilt != null)
                {
                    return (bool)resuilt;
                }

                throw new InvalidOperationException(
                    string.Format("Cannot find name or password with paramrters: {0}, {1}",
                    name, password
                    ));
            }
        }
    }
}
