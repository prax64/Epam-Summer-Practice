using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            //foreach (var item in bll.GetLibrary())
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(bll.GetBook(1));
            //Console.WriteLine(bll.AddBook("товарища", "Эрих Мария Ремарк", 1945));

            //Console.WriteLine(bll.RemoveBook(4));

            //Console.WriteLine(bll.EditBook(1,"товар213jjjища", 1945));

            //foreach (var item in bll.GetAllBooksByAuthor("Эрих Мария Ремарк"))
            //{
            //    Console.WriteLine(item);
            //}
            //////////////
            var bllUser = DependencyResolver.Instance.UserLogic;
            //Console.WriteLine(bllUser.AuthenticationUser("Admin", "Password"));

            //Console.WriteLine(bllUser.GetUserInfo("Admin"));

            Console.WriteLine(bllUser.EditUser(1, "Adm1n", "Password", "Admin@gmail.com"));
        }
    }
}
