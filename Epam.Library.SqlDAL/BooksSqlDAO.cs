using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.Common.Entities;
using Epam.Library.DAL.Interfaces;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.Library.DAL.SqlDAL
{
    public class BooksSqlDAO : IBooksDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public Book AddBook(string name, string author, int yearOfPublication)
        {
            using (_connection)
            {
                var stProc = "Book_Add";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@Name", name);
                comnand.Parameters.AddWithValue("@Author_name", author);
                comnand.Parameters.AddWithValue("@YearOfPublication", yearOfPublication);

                _connection.Open();

                var resuilt = comnand.ExecuteScalar();

                if (resuilt != null)
                {
                    return new Book(
                        id: (int)resuilt,
                        name: name,
                        author: author,
                        yearOfPublication: yearOfPublication);
                }

                throw new InvalidOperationException(
                    string.Format("Cannot add Book with paramrters: {0}, {1}, {2}",
                    name, author, yearOfPublication
                    ));
            }
        }

        public Book RemoveBook(int id)
        {
            using (_connection)
            {
                var stProc = "Book_Remove";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = comnand.ExecuteReader();

                if (reader.Read())
                {
                    return new Book(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        author: reader["Author"] as string,
                        yearOfPublication: (int)reader["YearOfPublication"]);
                }


                throw new InvalidOperationException("Cannot find Book with Id = " + id);
            }
        }

        public Book EditBook(int id, string newName, int newYearOfPublication)
        {
            using (_connection)
            {
                var stProc = "Book_Edit";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@id", id);
                comnand.Parameters.AddWithValue("@Name", newName);
                comnand.Parameters.AddWithValue("@YearOfPublication", newYearOfPublication);

                _connection.Open();

                var reader = comnand.ExecuteReader();

                if (reader.Read())
                {
                    return new Book(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        author: reader["Author"] as string,
                        yearOfPublication: (int)reader["YearOfPublication"]);
                }

                throw new InvalidOperationException("Cannot find Book with Id = " + id);
            }
        }


        public Book GetBook(int id)
        {
            using (_connection)
            {
                var stProc = "Book_GetById";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = comnand.ExecuteReader();

                if (reader.Read())
                {
                    return new Book(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        author: reader["Author"] as string,
                        yearOfPublication: (int)reader["YearOfPublication"]);
                }

                throw new InvalidOperationException("Cannot find Book with Id = " + id);
            }
        }
        public IEnumerable<Book> GetLibrary(bool orderedById = true)
        {
            using (_connection)
            {
                var query = "SELECT Id, Name, Author, YearOfPublication FROM Books" +
                    (orderedById ? " ORDER BY Id" : "");

                var comnand = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = comnand.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Book(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        author: reader["Author"] as string,
                        yearOfPublication: (int)reader["YearOfPublication"]);
                }
            }
        }

        public IEnumerable<Book> GetAllBooksByAuthor(string author)
        {
            using (_connection)
            {
                var stProc = "AllBooksByAuthor";

                var comnand = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                comnand.Parameters.AddWithValue("@Author", author);

                _connection.Open();

                var reader = comnand.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Book(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        author: reader["Author"] as string,
                        yearOfPublication: (int)reader["YearOfPublication"]);
                }
            }
        }

    }
}
