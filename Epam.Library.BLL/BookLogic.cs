using Epam.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.DAL.JsonDAL;
using Epam.Library.DAL.Interfaces;
using Epam.Library.BLL.Interfaces;

namespace Epam.Library.BLL.BLL
{
    public class BookLogic : ILibraryLogic
    {
        private ILibraryDAO _bookDAO;
        public BookLogic(ILibraryDAO bookDAO) =>
            _bookDAO = bookDAO;
        public bool AddBook(Book book) =>
            _bookDAO.AddBook(book);

        public void RemoveBook(Guid id) =>
            _bookDAO.RemoveBook(id);    
        public void RemoveBook(Book book) => RemoveBook(book.Id);

        public void EditBook(Guid id, string newName, string newAuthor, int newYearOfPublication) =>
            _bookDAO.EditBook(id, newName, newAuthor, newYearOfPublication);
        public Book GetBook(int id) => _bookDAO.GetBook(id);
        public IEnumerable<Book> GetLibrary(bool orderedById = true) =>
            _bookDAO.GetLibrary (orderedById);
    }
}
