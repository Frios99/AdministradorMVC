using CRUD_Ingenieria_web.Data;
using CRUD_Ingenieria_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace CRUD_Ingenieria_web.Controllers
{
    public class UserController : Controller
    {
        public EmployeeContext _db;
        public UserController(EmployeeContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View(_db.Users.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User account)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(account);
                _db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = account.Username + " successfully registered.";
            }
            return View("Login");
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(User user)
        {
            var usr = _db.Users.Single(u => u.Username == user.Username && u.Password == user.Password && u.role == u.role);
            if (usr != null)
            {

                HttpContext.Session.SetString("Id", usr.Id.ToString());
                HttpContext.Session.SetString("Username", usr.Username.ToString());
                HttpContext.Session.SetString("role", usr.role.ToString());
                return RedirectToAction("LoggedIn");

            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if(HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");

            }
        }
       

    }
}
