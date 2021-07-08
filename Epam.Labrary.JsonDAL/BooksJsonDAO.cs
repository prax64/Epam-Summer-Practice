using System;
using System.IO;
using Newtonsoft.Json;
using Epam.Library.Common.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.DAL.Interfaces;

namespace Epam.Library.DAL.JsonDAL
{
    public class BooksJsonDAO : ILibraryDAO
    {
        public const string JSON_FILES_PATH = @"C:\Users\storm1\source\repos\Library\Files";

        public void AddBook(Book book)
        {
            //string json = JsonConvert.SerializeObject(book);

            //File.WriteAllText(GetFilePathById(book.Id), json);
            throw new Exception();
        }

        public void RemoveBook(int id)
        {
            //if (File.Exists(GetFilePathById(id)))
            //{
            //    File.Delete(GetFilePathById(id));
            //}
            //else throw new FileNotFoundException(
            //    string.Format("File with name {0} at path {1} isn't created!", 
            //    GetFilePathById(id), JSON_FILES_PATH));
            throw new Exception();

        }

        public void EditBook(int id, string newName, string newAuthor, int newYearOfPublication)
        {
            //if (!File.Exists(GetFilePathById(id)))
            //{
            //    throw new FileNotFoundException(
            //    string.Format("File with name {0} at path {1} isn't created!", id, JSON_FILES_PATH));
            //}
            //Book book = JsonConvert.DeserializeObject<Book>(File.ReadAllText(GetFilePathById(id)));

            //book.EditName(newName);
            //book.EditAuthor(newAuthor);
            //book.EditYearOfPublication(newYearOfPublication);

            //File.WriteAllText(GetFilePathById(book.Id), JsonConvert.SerializeObject(book));
            throw new Exception();
        }
        public Book GetBook(int id)
        {
            throw new Exception();
        }
        public IEnumerable<Book> GetLibrary(bool orderedById = true)
        {
            throw new Exception();
        }
        public string GetFilePathById(Guid id) => JSON_FILES_PATH + id + ".json";

    }
}
