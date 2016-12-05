using AutoMapper;
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
    public class AppServicesController : Controller
    {
        MyModel db = new MyModel();
        // GET: AppServices
        public ActionResult Index()
        {
            string UserID = "";
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UserID = authTicket.UserData;
            }
            if (UserID != "")
            {
                IEnumerable<Services> UserServicesList = new ServicesFunctions().GetAllUserServices(Convert.ToInt32(UserID));
                return View(UserServicesList);
            }
            return RedirectToAction("Login", "User", new { @returnUrl = "/appservices/Index" });
        }
        [Authorize]
        // GET: AppServices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppServices/Create
        public ActionResult Create()
        {
            //IEnumerable<User> userlist = new UserFunctions().GetAllUsers();
            //Services Service = new Services();
            //Service.UserID = new SelectList(userlist, "user-ID", "UserID") ;
            //ViewBag.userlist = new SelectList(userlist, "user-ID", "UserID");
            Services Services = new Services();
            Services.UserList = new SelectList(new UserFunctions().GetAllUsers(), "ID", "first_name");

            return View(Services);
        }

        // POST: AppServices/Create
        [HttpPost]
        public ActionResult Create(Services collection)
        //public ActionResult Create(ServicesVM ServiceFormData)
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
                return RedirectToAction("Login", "User", new { @returnUrl = "/appservices/Create" });
            }
            else
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    collection.UserID = Convert.ToInt32(UserID);
                    db.servicess.Add(collection);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Validation Error! Service Not Added";
                    //Services Services = new Services();
                    //Services.UserList = new SelectList(new UserFunctions().GetAllUsers(), "ID", "first_name");

                    return View();
                }

            }


        }

        // GET: AppServices/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppServices/Edit/5
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

        // GET: AppServices/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppServices/Delete/5
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
