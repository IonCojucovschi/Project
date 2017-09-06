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
        IEnumerable<Routes> Routes();

    }

    public class RoutRepository : IRoutRepository
    {
        private readonly ISession _session;
        private readonly ISession _sessionSave;
        public RoutRepository(ISession session)
        {
            _session = session;
        }
        public RoutRepository()
        {
            _session = SesionFactoryUpdate.GetSession();/// initializam sesiunea....
            _sessionSave = SesionFactoryMapin.OpenSession();
        }
        public IEnumerable<Routes> Routes()
        {
            var p = _session.QueryOver<Routes>().SelectList(
                list => list.Select(x => x.name)).List();
            return p;
        }
    }
}
