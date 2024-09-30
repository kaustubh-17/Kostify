using CostEstimationSystem.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace CostEstimationSystem.Controllers
{
    [Authorize]
    public class QuotationController : Controller
    {
        CESRepository cesRepository;
        Registration reg;
        public QuotationController()
        {
            cesRepository = new CESRepository();
            reg = new Registration();
        }
        public ActionResult GetQuotation()
        {
            cartonPriceEstimator u = new cartonPriceEstimator();
            u.trade = (string)TempData["trade"];
            u.companyName = (string)TempData["companyName"];
            u.dimension = (string)TempData["dimension"];
            u.material = (string)TempData["material"];
            u.quantity = (int)TempData["quantity"];
            bool flag = true;
            if (u.material == "Steel")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(100 - u.quantity / 50, 40));
            }

            else if (u.material == "Fiberboard")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(90 - u.quantity / 50, 40));
            }

            else if (u.material == "Wood")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(80 - u.quantity / 50, 40));
            }

            else if (u.material == "Plastic" || u.material == "Aluminium")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(70 - u.quantity / 50, 40));
            }

            else if (u.material == "Shrinkwrap" || u.material == "Stretchwrap")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(60 - u.quantity / 50, 40));
            }

            else if (u.material == "Cardboard")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(50 - u.quantity / 50, 40));
            }

            else if (u.material == "Paperboard" || u.material == "Bubblewrap")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(40 - u.quantity / 50, 25));
            }

            else if (u.material == "Kraftpaper")
            {
                u.unitCost = Math.Ceiling((double)Math.Max(30 - u.quantity / 50, 25));
            }
            else
            {
                flag = false;
            }
            if (flag)
            {
                cesRepository.saveEstimatedCost(u);
            }
            Estimator e = new Estimator();
            e.trade = u.trade;
            e.quantity = u.quantity;
            e.unitCost = u.unitCost;
            e.material = u.material;
            e.companyName = u.companyName;
            e.dimension = u.dimension;
            TempData["qtrade"] = u.trade;
            TempData["qcompany"] = u.companyName;
            TempData["qmaterial"] = u.material;
            TempData["qquantity"] = u.quantity;
            TempData["qdimension"] = u.dimension;
            TempData["qcost"] = u.unitCost;
            ViewBag.sellers = cesRepository.GetAllSellers();
            return View(e);
        }
        [HttpPost]
        public ActionResult GetQuotation(string key1, string key2)
        {
            quotation q = new quotation();
            q.trade = (string)TempData["qtrade"];
            q.company = (string)TempData["qcompany"];
            q.dimension = (string)TempData["qdimension"];
            q.material = (string)TempData["qmaterial"];
            q.quantity = (int)TempData["qquantity"];
            q.seller_id = int.Parse(key1);
            q.seller_name = key2;
            HttpContext currentContext = System.Web.HttpContext.Current;
            
            string userName = User.Identity.Name;
            q.buyer_name = reg.GetBuyerName(userName);
            q.buyer_id = 1;
            q.unit_cost = (double)TempData["qcost"];
            cesRepository.saveQuotation(q);
          
            return RedirectToAction("Dashboard", "Profile");
        }
    }
}