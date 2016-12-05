using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scheduling_App.Models;
using Scheduling_App.ViewModels;
using AutoMapper;
using System.Web.Security;
using AutoMapper.Mappers;
using Scheduling_App.Utils.Helpers;

namespace Scheduling_App.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("LoggedIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (MyModel db = new MyModel())
                {
                    //User u = new Models.User();
                    try
                    {
                        //var usr = Helpers.AuthenticateUser(user.Email.ToString(), user.Password.ToString());
                        var usr = db.users.Single(u => u.email == user.Email && u.password == user.Password);
                        if (usr != null)
                        {
                            var authTicket = new FormsAuthenticationTicket(
                                                 1,  //Version
                                                 usr.email, //Username/Email
                                                 DateTime.Now,  //Created
                                                 DateTime.Now.AddMinutes(120), //Expires
                                                 user.KeepMeLoggedIn,  //Persistent?
                                                 usr.ID.ToString()//_user.ID.ToString()
                                                 );

                            string EncryptedTicket = FormsAuthentication.Encrypt(authTicket);
                            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncryptedTicket);
                            HttpContext.Response.Cookies.Add(authCookie);
                            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Create", "AppServices");
                            }
                            
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email or Password is Not valid ");
                        }
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "Exception Email or Password is Not valid ");
                    }


                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult LoggedIn()
        {
            return View();

        }

        public ActionResult Register()
        {
            if (!Request.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "AppServices");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserVM user)
        {

            if (ModelState.IsValid)
            {
                using (MyModel db = new MyModel())
                {
                    User register = new Models.User();
                    Mapper.Map(user, register);
                    register.password = DataProtection.Encrypt(register.password);
                    register.CreatedOn = DateTime.Now;
                    register.RoleID = 1;

                    Mapper.Map(user, register);
                    db.users.Add(register);
                    db.SaveChanges();

                    var authTicket = new FormsAuthenticationTicket(
                    1,  //Version
                    register.email, //Username/Email
                    DateTime.Now,  //Created
                    DateTime.Now.AddMinutes(120), //Expires
                    false,  //Persistent? for remember me 
                    register.ID.ToString()  //Role
                    );
                    Console.Write("ticket: ", authTicket);
                    string EncryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Settime", "TimeSlots");
                }
                ModelState.Clear();
                ViewBag.Message = user.first_name + " " + user.last_name + "Registration Done!!";

            }
            return View(user);

        }

        public User get_User(string email)
        {
            using (MyModel db = new MyModel())
            {
                try
                {
                    var user = db.users.Single(u => u.email == email);
                    if (user != null)
                    {
                        return user;
                    }
                    else
                        return null;
                }
                catch (Exception e)
                {
                    Console.Write("GetUser Excetion: ", e);
                    return null;
                }

            }
        }


        public ActionResult SearchResults()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult SearchResults(string value)
        {
            //using (MyModel db = new MyModel())
            //{
           // value = "mobeen";
            var db = new MyModel();
            //var user = db.Database.SqlQuery<User>("select * from user_services where username like('%"+value+ "%') OR service_name like('%" + value + "%')").ToList();
            //var user_services = from us in db.userServicess
            //                        // where u.username.Contains(value)
            //                    select us;
            var user = from u in db.users
                       select u;
            //var services = from s in db.servicess
            //               select s;

            //IEnumerable < User > list = new Helpers().SearchResult(value);
            // if (!String.IsNullOrEmpty(value))
            //{
            user = user.Where(u => u.username.Contains(value));
                //user = from u in db.users
                //       join us in db.userServicess on u.ID equals us.UserID
                //       join s in db.servicess on us.ServicesID equals s.ID
                //       where u.username.Contains(value) || s.service_name.Contains(value)
                //       select new User
                //       {
                //           username = u.username,
                //           email = u.email,
                //           phone = u.phone,
                //           service_name = s.service_name,

                //       };
            //}

            return PartialView("~/Views/User/_Search.cshtml", user);
            //}

        }
    }
}