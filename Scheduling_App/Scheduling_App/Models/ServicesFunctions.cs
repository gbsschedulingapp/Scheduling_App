using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling_App.Models
{
    public class ServicesFunctions
    {
        MyModel db = new MyModel();
        public IEnumerable<Services> GetAllServices()
        {
            return db.servicess.AsEnumerable();
        }
        public IQueryable<Services> GetAllUserServices( Nullable<int> id)
        {
            var query = db.servicess.Where(en => en.UserID == id);
            return query;
        }
    }
}