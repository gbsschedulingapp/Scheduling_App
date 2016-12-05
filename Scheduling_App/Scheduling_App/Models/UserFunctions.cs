using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling_App.Models
{
    public class UserFunctions
    {
        MyModel db = new MyModel();
        public IEnumerable<User> GetAllUsers()
        {
            return db.users.AsEnumerable();
        }
    }
}