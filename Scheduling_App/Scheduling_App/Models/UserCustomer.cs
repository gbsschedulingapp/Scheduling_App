using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scheduling_App.Models
{
    public class UserCustomer
    {
        public int ID { get; set; }               
        public int UserID { get; set; }
        public int CustomerID { get; set; }

        [NotMapped]
        public List<User> UserCustomerList { get; set; }
    }
}