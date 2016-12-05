using Scheduling_App.Models;
using Scheduling_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Scheduling_App.Controllers
{
    public class TimeSlotsController : Controller
    {
        MyModel db = new MyModel();
        // GET: TimeSlots
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Settime()
        {
            string user_id = "";
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                user_id = authTicket.UserData;
            }
            if (user_id != "")
            {
                return View();
            }
            return RedirectToAction("Login", "User", new { @returnUrl = "/timeslots/settime" });
        }

        //4. AJAX Call
        
        [HttpPost]
        public ActionResult Settime(List<DateTime> data)
        {
            TimeSpan t1, t2;
            if(data != null)
            {
                TimeSlots timeslots = new TimeSlots();
                string user_id = "";
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    user_id = authTicket.UserData;
                }
                if (user_id != "")
                {
                    t1 = convert_time(data[0]);
                    t2 = convert_time(data[1]);
                    store_timeSlots(user_id, "Monday", t1, t2);

                    
                    t1 = convert_time(data[2]);
                    t2 = convert_time(data[3]);
                    store_timeSlots(user_id, "Tuesday", t1, t2);

                    t1 = convert_time(data[4]);
                    t2 = convert_time(data[5]);
                    store_timeSlots(user_id, "Wednesday", t1, t2);

                    t1 = convert_time(data[6]);
                    t2 = convert_time(data[7]);
                    store_timeSlots(user_id, "Thursday", t1, t2);

                    t1 = convert_time(data[8]);
                    t2 = convert_time(data[9]);
                    store_timeSlots(user_id, "Friday", t1, t2);

                    return Json("success");
                }
                return RedirectToAction("Login", "User", new { @returnUrl = "/timeslots/settime" });

            }
            else
            {
                return Json("error");
            }
        }

        /// <summary>
        /// Function to store the time slot of each day in database
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="day"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        private void store_timeSlots(string user_id, string day, TimeSpan t1, TimeSpan t2)
        {
            TimeSlots timeslots = new TimeSlots();
            timeslots.UserID = int.Parse(user_id);
            timeslots.day = day;
            timeslots.available_from = t1;
            timeslots.available_to = t2;
            if ((t1.ToString() == "00:00:00") && (t2.ToString() == "00:00:00"))
            {
                timeslots.is_holiday = true;
            }
            else
            {
                timeslots.is_holiday = false;
            }

            db.timeSlotss.Add(timeslots);
            db.SaveChanges();
        }

        /// <summary>
        /// function to convert the user given time into to timespan 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private TimeSpan convert_time(DateTime dateTime)
        {
            TimeSpan dt;
            string time;
            if (dateTime == null)
            {
                time = "00:00:00";
                dt = TimeSpan.Parse(time);
                return dt;
            }
            else
            {
                time = dateTime.ToString("HH:mm:ss");
                dt = TimeSpan.Parse(time);
                return dt;
            }
        }
    }
}