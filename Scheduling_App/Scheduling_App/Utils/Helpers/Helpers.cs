using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scheduling_App.Models;
using System.Diagnostics;

namespace Scheduling_App.Utils.Helpers
{
    public class Helpers
    {
        MyModel db = new MyModel();

        public int GetCurrentUserID(string Email)
        {
            
            return db.users.FirstOrDefault(u => u.email == Email).ID;
        }

        public User AuthenticateUser(string email, string password)
        {          
            return db.Database.SqlQuery<User>("Select * from User where email = '" + email + "' and password = '" + password + "'").FirstOrDefault();
        }

        public int CheckUserEmail(string email)
        {
            int userId = (from x in db.users
                          where x.email == email
                          select x.ID).SingleOrDefault();

            if (userId > 0)
            {
                // user exists
                return userId;
            }
            else {
                // user does not exist
                return 0;
            }
        }

        //User Customers Functions

        public Boolean CheckUserCustomers(int UserId , int CustomerID)
        {
            int userchck = (from x in db.UserCustomers
                            where x.UserID == UserId && x.CustomerID == CustomerID
                            select x.UserID).FirstOrDefault();

            if (userchck > 0)
            {
                Debug.WriteLine("The value of the pageNumber1 variable is {0}", userchck);
                // user exists
                return true;
                
            }
            else {
                // user does not exist
                return false;
            }
        }

        public IEnumerable<User> getusercustomers(int userid)
        {            
            var customers = db.UserCustomers.Where(uc => uc.UserID == userid).ToList();
            var users = db.users.ToList();
            var list = from usr in customers
                       join us in users
                       on usr.CustomerID equals us.ID
                       select new User
                       {
                           first_name = us.first_name,
                           last_name = us.last_name,
                           email = us.email,
                           phone =  us.phone
                       };

            return list;
        }

        //Appointment Functions

        public IEnumerable<User> GetUserResquestedAppointments(int userid)
        {
            var appointments = db.appointments.Where(app => app.UserID == userid).ToList();
            var users = db.users.ToList();
            var services = db.servicess.ToList();

            var list = from app in appointments
                       join usr in users
                       on app.UserID equals usr.ID
                       join ser in services
                       on app.UserServicesID equals ser.ID
                       join to_usr in users
                       on app.AppointmentID_to equals to_usr.ID
                       select new User
                       {
                           first_name = usr.first_name,
                           last_name = usr.last_name,
                           phone = usr.phone,
                           email = usr.email,
                           service_name = ser.service_name,
                           appointment_date = app.appointment_date,
                           appointment_time = app.appointment_time,
                           appointment_details = app.appointment_details,
                           to_email = to_usr.email,
                           to_first_name = to_usr.first_name,
                           to_last_name = to_usr.last_name
                       };

            return list;        

        }

        public IEnumerable<User> SearchResult(string value)
        {
            var res = from us in db.userServicess join u in db.users
                      on us.UserID equals u.ID join s in db.servicess
                      on us.ServicesID equals s.ID
                      where u.username.Contains(value) || s.service_name.Contains(value)
                      select new User
                      {
                         first_name = u.first_name,
                         last_name = u.last_name,
                         email = u.email,
                         phone = u.phone,
                         service_name = s.service_name
                         //service_detail = s.service_details

                      };

            return res;
        }
    }
}