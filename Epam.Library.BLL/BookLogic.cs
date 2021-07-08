using Epam.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.DAL.Interfaces;
using Epam.Library.BLL.Interfaces;

namespace Epam.Library.BLL.BLL
{
    public class BookLogic : ILibraryLogic
    {
        private ILibraryDAO _bookDAO;
        public BookLogic(ILibraryDAO bookDAO) =>
            _bookDAO = bookDAO;
        public Book AddBook(string name, string author, int yearOfPublication) =>
            _bookDAO.AddBook(name, author, yearOfPublication);

        public Book RemoveBook(int id) =>
            _bookDAO.RemoveBook(id);    
        public void RemoveBook(Book book) => RemoveBook(book.Id);

        public Book EditBook(int id, string newName, int newYearOfPublication) =>
            _bookDAO.EditBook(id, newName, newYearOfPublication);
        public Book GetBook(int id) => _bookDAO.GetBook(id);
        public IEnumerable<Book> GetLibrary(bool orderedById = true) =>
            _bookDAO.GetLibrary (orderedById);
        public IEnumerable<Book> GetAllBooksByAuthor(string author) =>
            _bookDAO.GetAllBooksByAuthor(author);
    }
}
