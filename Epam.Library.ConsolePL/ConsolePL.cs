using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.BLL.BLL;
using Epam.Library.Common.Entities;
using Epam.Library.Dependencies;

namespace Epam.Library.ConsolePL
{
    class ConsolePL
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.BookLogic;

            var str = Console.ReadLine();

            bll.AddBook(new Book() )
            
        }
    }
}
