using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CostEstimationSystem.Models;
using DAL;

namespace CostEstimationSystem.Controllers
{
    public class AccountController : Controller
    {
        Registration reg;
        public AccountController()
        {
            reg = new Registration();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Signup model)
        {
            if(model.email == null)
            {
                buyer b = new buyer();
                seller s = new seller();
                if (model.role == "buyer")
                {
                    b.username = model.username;
                    b.password = model.password;
                    buyer loginBuyer = reg.LoginBuyer(b);
                    if (loginBuyer != null)
                    {
                        ViewBag.message = "Buyer Login Success";
                        TempData["heading"] = loginBuyer.name;
                        Session["heading"] = loginBuyer.name;
                        TempData["username"] = loginBuyer.username;
                        TempData["email"] = loginBuyer.email;
                        TempData["phone"] = loginBuyer.phone;
                        TempData["role"] = "Buyer";
                        TempData["secondButton"] = "My Orders";
                        return RedirectToAction("Dashboard", "Profile");
                    }
                    else
                    {
                        ViewBag.message = "Credentials not found";
                        return View();
                    }
                }
                else
                {
                    s.username = model.username;
                    s.password = model.password;
                    seller loginSeller = reg.LoginSeller(s);
                    if (loginSeller != null)
                    {
                        ViewBag.message = "Seller Login Success";
                        TempData["name"] = loginSeller.name;
                        TempData["username"] = loginSeller.username;
                        TempData["email"] = loginSeller.email;
                        TempData["phone"] = loginSeller.phone;
                        TempData["role"] = "Seller";
                        TempData["secondButton"] = "My Quotations";
                        return RedirectToAction("Dashboard", "Profile");
                    }
                    else
                    {
                        ViewBag.message = "Credentials not found";
                        return View();
                    }
                }
            }
            else
            {
                if (model.role == "buyer")
                {
                    buyer b = new buyer();
                    b.name = model.name;
                    b.email = model.email;
                    b.phone = model.phone;
                    b.username = model.username;
                    b.password = model.password;
                    if (reg.SignupBuyer(b))
                        return RedirectToAction("Login");
                }
               else
                {
                    seller s = new seller();
                    s.name = model.name;
                    s.email = model.email;
                    s.phone = model.phone;
                    s.username = model.username;
                    s.password = model.password;
                    if (reg.SignupSeller(s))
                        return RedirectToAction("Login");
                }
            }
            return View();
        }
        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Signup signup)
        {           
            if (signup.role == "buyer")
            {
                buyer b = new buyer();
                b.name =signup.name;
                b.email = signup.email;
                b.phone = signup.phone;
                b.username = signup.username;
                b.password = signup.password;
                if (reg.SignupBuyer(b))
                    return RedirectToAction("Login");
                else
                {
                    ViewBag.signupFailed = "Username already exists, choose another.";
                    return View();
                }
                   
            }
            if (signup.role == "seller")
            {
                seller s = new seller();
                s.name = signup.name;
                s.email = signup.email;
                s.phone =signup.phone;
                s.username = signup.username;
                s.password = signup.password;
                if (reg.SignupSeller(s))
                    return RedirectToAction("Login");
            }
            else
            {
                ViewBag.signupFailed = "Username already exists, choose another.";
                return View();
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            buyer b = new buyer();
            seller s = new seller();
            if (fc["role"] == "buyer")
            {
                b.username = fc["Username"];
                b.password = fc["Password"];
                try
                {
                    buyer loginBuyer = reg.LoginBuyer(b);
                    FormsAuthentication.SetAuthCookie(b.username, false);
                    ViewBag.message = "Buyer Login Success";
                    TempData["heading"] = loginBuyer.name;
                    TempData["username"] = loginBuyer.username;
                    TempData["email"] = loginBuyer.email;
                    TempData["phone"] = loginBuyer.phone;
                    TempData["role"] = "Buyer";
                    TempData["secondButton"] = "My Orders";
                    if(loginBuyer!=null)
                    return RedirectToAction("Dashboard", "Profile");
                }
                catch (Exception e)
                {
                    ViewBag.message = "Credentials not found";
                    return View();
                }
                return View();
            }
            else
            {
                s.username = fc["Username"];
                s.password = fc["Password"];
                try
                {
                    seller loginSeller = reg.LoginSeller(s);
                    FormsAuthentication.SetAuthCookie(s.username, false);
                    ViewBag.message = "Seller Login Success";
                    TempData["heading"] = loginSeller.name;
                    TempData["username"] = loginSeller.username;
                    TempData["email"] = loginSeller.email;
                    TempData["phone"] = loginSeller.phone;
                    TempData["role"] = "Seller";
                    TempData["secondButton"] = "My Quotations";
                    if(loginSeller!=null)
                    return RedirectToAction("Dashboard", "Profile");
                }
                catch (Exception)
                {
                    ViewBag.message = "Credentials not found";
                    return View();
                }
                return View();
            }
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult ChangeCredentials()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeCredentials(Login login)
        {
            string username = login.username;
            string password = login.password;
            if(reg.ChangeCredentials(username, password));
            ViewBag.successChange = "Credentials updated";
            return View();
        }

    }
}