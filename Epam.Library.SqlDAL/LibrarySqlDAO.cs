using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.Common.Entities;
using Epam.Library.DAL.Interfaces;

namespace Epam.Library.DAL.SqlDAL
{
    public class LibrarySqlDAO : ILibraryDAO
    {

        public void AddBook(Book book)
        {

        }

        public void RemoveBook(Guid id)
        {

        }

        public void EditBook(Guid id, string newName, string newAuthor, int newYearOfPublication)
        {

        }


        public Book GetBook(int id)
        {
            throw new Exception();
        }
        public IEnumerable<Book> GetLibrary(bool orderedById)
        {
            throw new Exception();
        }

    }
}
