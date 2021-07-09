using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Library.BLL;
using Epam.Library.BLL.BLL;
using Epam.Library.BLL.Interfaces;
using Epam.Library.DAL.Interfaces;
using Epam.Library.DAL.SqlDAL;

namespace Epam.Library.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE
        private static DependencyResolver _instance;

        public static DependencyResolver Instance =>
             _instance ??= new DependencyResolver();
        #endregion

        public IBooksDAO BookDAO => new BooksSqlDAO();

        public IBooksLogic BookLogic => new BookLogic(BookDAO);

        public IUserDAO UserDAO => new UserSqlDAO();

        public IUserLogic UserLogic => new UserLogic(UserDAO);

    }
}
