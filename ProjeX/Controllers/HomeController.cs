using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeX.Models;

namespace ProjeX.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login()
        {  
            if (Session["LoginInfo"] != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index()
        {

            if (Session["LoginInfo"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                SinemaxEntities db = new SinemaxEntities();
                List<FilmResimleri> filmresim = db.FilmResimleri.ToList();
                return View(filmresim);
            }
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            SinemaxEntities db = new SinemaxEntities();
            var customer = (from info in db.Customer
                            where info.Email.Equals(email) && info.Password.Equals(password)
                            select info).SingleOrDefault();
            if (customer != null)
            {
                Session.Add("LoginInfo", customer);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult Message()
        {
            return View();
        }
    }
}