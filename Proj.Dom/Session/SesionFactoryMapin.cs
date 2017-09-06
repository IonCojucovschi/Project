using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Proj.Dom.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom.Session
{
    public class SesionFactoryMapin
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012
                 .ConnectionString(@"Data Source=MDDSK40069;Initial Catalog=MyProjectDataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                 .ShowSql()).Mappings(m => m.FluentMappings
                 .AddFromAssemblyOf<Users>())
                 //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                 .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


    }
}
