using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.Common.Entities;

namespace Epam.Library.BLL.Interfaces
{
    public interface IBooksLogic
    {
        Book AddBook(string name, string author, int yearOfPublication);

        Book RemoveBook(int id);
        void RemoveBook(Book book);

        Book EditBook(int id, string newName, int newYearOfPublication);

        Book GetBook(int id);
        IEnumerable<Book> GetLibrary(bool orderedById = true);

        IEnumerable<Book> GetAllBooksByAuthor(string author);
    }
}
