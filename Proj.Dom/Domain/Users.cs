using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Dom.Domain
{
   public  class Users:EntityBase
    {
        
        public virtual string name { get; set; }
        public virtual string surname { get; set; }
        public virtual int age { get; set; }
        public virtual string phone { get; set; }
        public virtual string info { get; set; }
        public virtual UserRating Rat_ID { get; set; }

    }
   public class UserRating:EntityBase
    {
        
        public virtual int points { get; set; }
        public virtual Users userID { get; set; }

    }
}
