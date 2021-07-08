using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.Common.Entities;

namespace Epam.Library.BLL.Interfaces
{
    public interface ILibraryLogic
    {
        bool AddBook(Book book);

        void RemoveBook(Guid id);
        void RemoveBook(Book book);

        void EditBook(Guid id, string newName, string newAuthor, int newYearOfPublication);

        Book GetBook(int id);
        IEnumerable<Book> GetLibrary(bool orderedById = true);
    }
}
