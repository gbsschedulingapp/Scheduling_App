using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling_App.Models
{
    public class UserServices
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ServicesID { get; set; }
        public Nullable<System.DateTime> services_time { get; set; }

    }
}