using Proj.Dom.Repository;
using Proj.Dom.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom
{
    class Program
    {
       private static  IRoutRepository repo;
        private static IUsersRepository usrrep;
        static void getRoutes()
        {
            var re = repo.ListRout();
            re.ToString();
        }
        static void getRou()
        {
            var re = repo.Routes();
            re.ToString();
        }

        static void getUser()
        {
            var usr =usrrep.GetAll();
            usr.ToString();
        }
        static void Main(string[] args)
        {
            using (var session = SesionFactoryUpdate.GetSession())
            {
                repo = new RoutRepository();
                usrrep = new UsersRepository();
                getRoutes();
                //getRou();

                Console.WriteLine("After first ...");
               // getUser();
                Console.ReadLine();
            }
            
        }
    }
}
