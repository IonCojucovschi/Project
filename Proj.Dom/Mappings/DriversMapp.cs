using FluentNHibernate.Mapping;
using Proj.Dom.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom.Mappings
{
    public class DriversMapp : ClassMap<Drivers>
    {
        public DriversMapp()
        {
            Id(x => x.Id).Not.Nullable();
            Map(x => x.name).Not.Nullable();
            Map(x => x.surname).Not.Nullable();
            Map(x => x.Login).Not.Nullable().Unique();
            Map(x => x.Pass).Not.Nullable();
            Map(x => x.salary).Not.Nullable();
            Map(x => x.OterInfo);
            References<Vehicle>(x => x.Vehicle_ID);
            References<Routes>(x => x.Rout_ID);
        }

    }
    public class VehicleMap : ClassMap<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.Id).Not.Nullable();
            Map(x => x.model).Not.Nullable();
            Map(x => x.carNumber).Not.Nullable();
            Map(x => x.Information);
            HasMany<Drivers>(x => x.Driver_ID).Inverse().Cascade.All();
            References<Routes>(x => x.Route_ID);
        }
    }
    public class RoutesMap : ClassMap<Routes>
    {
        public RoutesMap()
        {
            Id(x => x.Id).Not.Nullable();
            Map(x => x.name).Not.Nullable();
            Map(x => x.curse).Not.Nullable();
            Map(x => x.oterInfor);
            HasMany<Drivers>(x => x.Driver_ID).Inverse().Cascade.All();
            HasMany<Vehicle>(x => x.Vehicle_ID).Inverse().Cascade.All();
        }
    }
}
