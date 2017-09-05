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
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers(int page);
        IEnumerable<Users> GetByName();
        IEnumerable<Users> GetById(int ID);
        IEnumerable<Users> GetAll();
    }

    public class UsersRepository : IUsersRepository
    {    /// <summary>
         /// this rtepository may be initialized by initiatin an interface of this. in class where we want to add element of this repo.
         /// </summary>
        private readonly ISession _session;
        public UsersRepository(ISession session)
        {
            _session = session;
        }
        public UsersRepository()
        {
            _session = SesionFactoryUpdate.GetSession();/// initializam sesiunea....
        }
        public IEnumerable<Users> GetAll()
        {
            return _session.QueryOver<Users>().List();
        }


        public IEnumerable<Users> GetAllUsers(int page)
        {
            int pageSize = 5; /// numarul de itemi pe pagina
            return _session.QueryOver<Users>().
                OrderBy(t=>t.id).Asc.Skip((page-1)*pageSize).Take(pageSize).List<Users>();
        }

        public IEnumerable<Users> GetById(int ID)
        {
            return _session.QueryOver<Users>().Where(x => x.id == ID).List();
        }

        public IEnumerable<Users> GetByName()
        {
            throw new NotImplementedException();
        }
    }
}
