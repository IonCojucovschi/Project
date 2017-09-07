using NHibernate;
using Proj.Dom.Domain;
using Proj.Dom.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom.Repository
{
    public interface IRoutRepository
    {
        IEnumerable<string> Routes();
        IList<Routes> ListRout();
    }

    public class RoutRepository : IRoutRepository
    {
        private readonly ISession _session;

        public RoutRepository()
        {
            _session = SesionFactoryUpdate.GetSession();/// initializam sesiunea....
          
        }
        public IEnumerable<string> Routes()
        {
            var p = _session.QueryOver<Routes>().SelectList(
                list => list.Select(x => x.name)).List<string>();
            return p;
        }
        public IList<Routes> ListRout()
        {
           
            return _session.QueryOver<Routes>().List<Routes>();

        }
    }
}
