using Scheduling_App.Models;
using Scheduling_App.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Scheduling_App.Utils.Helpers;
using System.Net.Mail;
using System.Text;

namespace Scheduling_App.Controllers
{
    public class AppointmentController : Controller
    {
        MyModel db = new MyModel();

        // GET: Appointment
        
        public ActionResult Index()
        {
            string UserID = "";
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UserID = authTicket.UserData;
            }
            
            if (UserID == "")
            {
                return RedirectToAction("Login", "User", new { @returnUrl = "/appointment/Index" });

            }
            IEnumerable<User> UserRequestedAppointmentList = new Helpers().GetUserResquestedAppointments(Convert.ToInt32(UserID));
            return View(UserRequestedAppointmentList);

        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Appointment/Create
        
        public ActionResult Create()
        {
            string UserID = "";
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UserID = authTicket.UserData;
            }
            //ViewBag.email = UserID;
            //ViewBag.email2 = User.Identity.Name;
            if (UserID == "")
            {
                return RedirectToAction("Login", "User", new { @returnUrl = "/appointment/create" });
            }
            Appointment Appointment = new Appointment();
            Appointment.ServicesList = new SelectList(new ServicesFunctions().GetAllServices(), "ID", "service_name");
            return View(Appointment);
        }

        // POST: Appointment/Create
        [HttpPost]
        
        public ActionResult Create(Appointment FormData)
        {
            int AppointmentID_to;
            string UserID = "";
            string email = "";
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UserID = authTicket.UserData;
            }
            //try
            //{
            // TODO: Add insert logic here
            if (UserID == "")
            {
                return RedirectToAction("Login", "User", new { @returnUrl = "/appointment/create" });
            }
            
            if (ModelState.IsValid)
            {
                User add_customer = new User();
                UserCustomer UserCustomer = new UserCustomer();

                int to_userid = new Helpers().CheckUserEmail(FormData.email);
                if (to_userid == 0)
                {

                    add_customer.first_name = FormData.first_name;
                    add_customer.last_name = FormData.last_name;
                    email = FormData.email;
                    add_customer.email = FormData.email;
                    add_customer.phone = FormData.phone;
                    //Add User Entry
                    db.users.Add(add_customer);
                    db.SaveChanges();

                    //Get the last Inserted User Id
                    //Assign it Appointment to User ID Model Form Data
                    AppointmentID_to = add_customer.ID;
                    FormData.AppointmentID_to = AppointmentID_to;
                    //From User ID
                    FormData.UserID = Convert.ToInt32(UserID);

                    //Add Entry To Appointment table
                    db.appointments.Add(FormData);
                    db.SaveChanges();

                    // sEND EMAIL TO USER
                    string from = "mobeen@globalbridgesol.com";
                    string to = email;
                    string subject = "testing subject";
                    string body = "testing body";
                    send_email(from, to, subject, body);

                    //Check if Customer Already Exist In Customers table
                    bool CheckCustomer = new Helpers().CheckUserCustomers(Convert.ToInt32(UserID), AppointmentID_to);
                    //If Customer Doesnt Not Exist then Add New Entry To Customers table
                    if (CheckCustomer == false)
                    {
                        //Add Entry To Customer Table
                        UserCustomer.UserID = Convert.ToInt32(UserID);
                        UserCustomer.CustomerID = AppointmentID_to;
                        db.UserCustomers.Add(UserCustomer);
                        db.SaveChanges();
                    }


                }
                else
                {
                    FormData.AppointmentID_to = to_userid;
                    //From User ID
                    FormData.UserID = Convert.ToInt32(UserID);
                    email = FormData.email;
                    db.appointments.Add(FormData);
                    db.SaveChanges();
                    // send email to user
                    string from = "mobeen@globalbridgesol.com";
                    string to = email;
                    string subject = "testing subject";
                    string body = "testing body";
                    send_email(from, to, subject, body);

                    //if ()
                    //{
                    //    System.Diagnostics.Debug.WriteLine("dONE");
                    //}
                    //Check if Customer Already Exist In Customers table
                    bool CheckCustomer = new Helpers().CheckUserCustomers(Convert.ToInt32(UserID), to_userid);
                    //If Customer Doesnt Not Exist then Add New Entry To Customers table
                    if (CheckCustomer == false)
                    {
                        //Add Entry To Customer Table
                        UserCustomer.UserID = Convert.ToInt32(UserID);
                        UserCustomer.CustomerID = to_userid;
                        db.UserCustomers.Add(UserCustomer);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Validation Error! AppointMent Not Added";
            }

            return RedirectToAction("Create");

        }

        private void send_email(string from, string to, string subject, string body)
        {
            try
            {
                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.Port = 587;
                SmtpClient.Host = "smtp.gmail.com"; ;
                SmtpClient.EnableSsl = true;
                SmtpClient.Timeout = 10000;
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new System.Net.NetworkCredential("mobeen@globalbridgesol.com", "globalbridgesol4me");
                // from, to, subject, body
                MailMessage mm = new MailMessage(from, to, subject, body);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mm.IsBodyHtml = true;

                SmtpClient.Send(mm);
                //Console.WriteLine("Email Sent : " + item);

            }
            catch (Exception ex)
            {
                throw ex;
                System.Diagnostics.Debug.WriteLine("dONE");
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
