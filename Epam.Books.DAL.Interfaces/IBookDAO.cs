using Epam.Library.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.DAL.Interfaces
{
    public interface IBookDAO
    {
        void AddBook(Book book);

        void RemoveBook(Guid id);

        void EditBook(Guid id, string newName, string newAuthor, int newYearOfPublication);
    }
}
