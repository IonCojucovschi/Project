using Proj.Dom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom
{
    class Program
    {
       static  IRoutRepository repo;
        static void getRoutes()
        {
            var re = repo.Routes();
            re.ToString();
        }
        static void Main(string[] args)
        {
            getRoutes();
        }
    }
}
