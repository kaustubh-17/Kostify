using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CostEstimationSystem.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Buyer
        [Authorize]
        public ActionResult Dashboard()
        {
            ViewBag.heading = TempData["heading"];
            ViewBag.username = TempData["username"];
            ViewBag.email = TempData["email"];
            ViewBag.phone = TempData["phone"];
            ViewBag.role = TempData["role"];
            ViewBag.secondButton = TempData["secondButton"];
            return View();
        }
    }
}