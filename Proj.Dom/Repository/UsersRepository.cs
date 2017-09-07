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
        IEnumerable<Users> GetAllUsers(int page,int NumItemPerPage);
        IEnumerable<Users> GetByName();
        IEnumerable<Users> GetAll();
        void Saving(Users usr);
        void Update(Users nw);
    }

    public class UsersRepository : IUsersRepository
    {    /// <summary>
         /// this rtepository may be initialized by initiatin an interface of this. in class where we want to add element of this repo.
         /// </summary>
        private readonly ISession _session;
        private readonly ISession _sessionSave;
        
        public UsersRepository()
        {
            _session = SesionFactoryUpdate.GetSession();/// initializam sesiunea....
            _sessionSave = SesionFactoryMapin.OpenSession();
        }

        public void Saving(Users usr)
        {
            using (var transaction = _sessionSave.BeginTransaction())
            {
                _sessionSave.Save(usr);
                transaction.Commit();
            }
        }
        public void Update(Users nw)
        {
            using (var transaction = _sessionSave.BeginTransaction())
            {
                var t = _sessionSave.Load<Users>(nw.Id);
                t.name = nw.name;
                t.surname = nw.surname;
                t.info = nw.info;
                t.phone = nw.phone;
                t.age=nw.age;


                _sessionSave.SaveOrUpdate(t);
                transaction.Commit();
            }
        }
        public IEnumerable<Users> GetAll()
        {
            return _session.QueryOver<Users>().List();
        }
       

        public IEnumerable<Users> GetAllUsers(int page, int pageSize)
        {
             /// numarul de itemi pe pagina
            return _session.QueryOver<Users>().
                OrderBy(t=>t.Id).Asc.Skip((page-1)*pageSize).Take(pageSize).List<Users>();
        }

       

        public IEnumerable<Users> GetByName()
        {
            throw new NotImplementedException();
        }
    }
}
