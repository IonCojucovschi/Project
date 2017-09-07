using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom.Domain
{
    public class Drivers : EntityBase
    {
        public virtual string name { get; set; }
        public virtual string surname { get; set; }
        public virtual string Login { get; set; }
        public virtual string Pass { get; set; }
        public virtual int age { get; set; }
        public virtual int salary { get; set; }
        public virtual string numberPH { get; set; }
        public virtual string OterInfo { get; set; }
        public virtual Vehicle Vehicle_ID { get; set; }
        public virtual Routes Rout_ID { get; set; }
    }

    public class Vehicle : EntityBase
    {

        public virtual string model { get; set; }
        public virtual string carNumber { get; set; }
        public virtual string Information { get; set; }
        public virtual Routes Route_ID { get; set; }
        public virtual IList<Drivers> Driver_ID { get; set; }
    }
    public class Routes : EntityBase
    {
        public virtual string name { get; set; }
        public virtual string curse { get; set; }
        public virtual string oterInfor { get; set; }
        public virtual IList<Vehicle> Vehicle_ID { get; set; }
        public virtual IList<Drivers> Driver_ID { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-3}\t\t{1,-3}\t\t{2,-3}", name,curse,oterInfor
                
                );
        }
    }

}
