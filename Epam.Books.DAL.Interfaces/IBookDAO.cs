using Epam.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.DAL.Interfaces
{
    public interface ILibraryDAO
    {
        Book AddBook(string name, string author, int yearOfPublication);

        Book RemoveBook(int id);

        void EditBook(int id, string newName, string newAuthor, int newYearOfPublication);

        Book GetBook(int id);
        IEnumerable<Book> GetLibrary(bool orderedById);
    }
}
