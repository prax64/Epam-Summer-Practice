using Epam.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.DAL.Interfaces
{
    public interface IBooksDAO
    {
        Book AddBook(string name, string author, int yearOfPublication);

        Book RemoveBook(int id);

        Book EditBook(int id, string newName, int newYearOfPublication);

        Book GetBook(int id);
        IEnumerable<Book> GetLibrary(bool orderedById);

        IEnumerable<Book> GetAllBooksByAuthor(string author);
    }
}
