using Scheduling_App.Models;
using Scheduling_App.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Scheduling_App.Controllers
{
    public class UserCustomerController : Controller
    {
        // GET: UserCustomer
        public ActionResult Index()
        {
            string UserID = "";
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UserID = authTicket.UserData;
            }
            IEnumerable<User> UserCustomerList = new Helpers().getusercustomers(Convert.ToInt32(UserID));
            return View(UserCustomerList);
        }

        // GET: UserCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCustomer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserCustomer/Edit/5
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

        // GET: UserCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserCustomer/Delete/5
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
