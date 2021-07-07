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
        private IBookDAO _bookDAO;
        public BookLogic(IBookDAO bookDAO) =>
            _bookDAO = bookDAO;
        public void AddBook(Book book) =>
            _bookDAO.AddBook(book);

        public void RemoveBook(Guid id) =>
            _bookDAO.RemoveBook(id);    
        public void RemoveBook(Book book) => RemoveBook(book.Id);

        public void EditBook(Guid id, string newName, string newAuthor, int newYearOfPublication) =>
            _bookDAO.EditBook(id, newName, newAuthor, newYearOfPublication);
    }
}
