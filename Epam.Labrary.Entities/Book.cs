using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Library.Common.Entities
{
    public class Book
    {
        public Book(int id, string name, string author, int yearOfPublication)
        {
            Id = id;
            Name = name;
            Author = author;
            YearOfPublication = yearOfPublication;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Author { get; private set; }

        public int YearOfPublication { get; private set; }

        public void EditName(string name)
        {
            if(name == null)
            {
                throw new ArgumentException("name", "Name string cannot be null!");
            }
            Name = name;
        }
        public void EditAuthor(string author)
        {
            if (author == null)
            {
                throw new ArgumentException("author", "Name string cannot be null!");
            }
            Author = author;
        }
        public void EditYearOfPublication(int yearOfPublication)
        {
            YearOfPublication = yearOfPublication;
        }

        public override string ToString() =>
            JsonConvert.SerializeObject(this);
    }
}
