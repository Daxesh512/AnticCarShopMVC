using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using AnticCarShopMVC.Models;

namespace AnticCarShopMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return
                View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Registration(TblUser tblUser)
        {
            using (AnticDTOEntities db = new AnticDTOEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblUsers.Add(tblUser);
                    db.SaveChanges();
                    ViewBag.message = "Registration Success";
                    ModelState.Clear();
                }
            }

            return View(tblUser);
        }

        public ActionResult Login(TblUser tblUser)
        {
            using (AnticDTOEntities db = new AnticDTOEntities())
            {
                if (ModelState.IsValid)
                {
                    var log = db.TblUsers.Where(a => a.userName.Equals(tblUser.userName) && a.password.Equals(tblUser.password)).FirstOrDefault();
                    if (log != null)
                    {
                        return RedirectToAction("Reservation");
                    }
                    db.SaveChanges();
                    ModelState.Clear();
                }
            }
            return View(tblUser);
        }


    }
}