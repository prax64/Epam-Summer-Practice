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
            using (_connection)
            {
                var stProc = "User_Edit";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@Id", id);
                comnand.Parameters.AddWithValue("@NewName", newName);
                comnand.Parameters.AddWithValue("@NewPassword", newPassword);
                comnand.Parameters.AddWithValue("@NewEmail", newEmail);

                _connection.Open();

                var reader = comnand.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        password: reader["Password"] as string,
                        email: reader["Email"] as string);
                }


                throw new InvalidOperationException("Cannot find Book with ID = " + id);
            }
        }

        public User GetUserInfo(string name)
        {
            using (_connection)
            {
                var stProc = "User_GetByName";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@Name", name);

                _connection.Open();

                var reader = comnand.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        email: reader["Email"] as string);
                }


                throw new InvalidOperationException("Cannot find Book with Name = " + name);
            }
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
