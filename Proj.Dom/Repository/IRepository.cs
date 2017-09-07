using NHibernate;
using NHibernate.Transform;
using Proj.Dom.Domain;
using Proj.Dom.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom.Repository
{
    public interface IRepository<T> where T:EntityBase
    {
        T GetById(int Id);
        T Load(int Id);
        IEnumerable<T> GetAll();
        void Save(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
    public class Repository<T> : IRepository<T> where T:EntityBase
    {
        private readonly ISession _session;
        public Repository()
        {
            _session = SesionFactoryUpdate.GetSession();/// initializam sesiunea....
            
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _session.QueryOver<T>().List();
        }

        public T GetById(int Id)
        {
            T rez = _session.QueryOver<T>().Where(x => x.Id == Id).SingleOrDefault<T>();
            return rez;
        }

        public T Load(int Id)
        {
            T rez = _session.QueryOver<T>().Where(x => x.Id == Id).SingleOrDefault<T>();
            return rez;
        }

        public void Save(T entity)
        {
            T rez = _session.QueryOver<T>().Where(x => x.Id == entity.Id).SingleOrDefault<T>();
            
        }

        public void Update(T entity)
        {
            T rez = _session.QueryOver<T>().Where(x => x.Id == entity.Id).SingleOrDefault<T>();
            
        }
    }
}
