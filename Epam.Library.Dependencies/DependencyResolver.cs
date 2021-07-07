using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.BLL.BLL;
using Epam.Library.BLL.Interfaces;
using Epam.Library.DAL.Interfaces;
using Epam.Library.DAL.JsonDAL;

namespace Epam.Library.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE
        private static DependencyResolver _instance;

        public static DependencyResolver Instance =>
             _instance ??= new DependencyResolver();
        #endregion

        public IBookDAO BookDAO => new BooksJsonDAO();

        public ILibraryLogic BookLogic => new BookLogic(BookDAO);

    }
}
