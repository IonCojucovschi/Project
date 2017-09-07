using FluentNHibernate.Mapping;
using Proj.Dom.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom.Mappings
{
    class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Id(x => x.Id).Not.Nullable();
            Map(x => x.name).Not.Nullable().Length(50);
            Map(x => x.surname).Not.Nullable().Length(50);
            Map(x => x.phone);
            Map(x => x.age).Not.Nullable();
            Map(x => x.info);
            HasOne(x => x.Rat_ID).Cascade.All();
        }

        class UserRatingMap : ClassMap<UserRating>
        {
            UserRatingMap()
            {
                Id(x => x.Id);
                Map(x => x.points);
                References(x => x.userID);
            }
        }


    }
}
