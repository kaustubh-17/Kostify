using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CostEstimationSystem.Models;

namespace CostEstimationSystem.Controllers
{

    [Authorize]
    public class BuyerController : Controller
    {
        // GET: Buyer
        CESRepository cesRepository;
        Registration reg;
        public BuyerController()
        {
            cesRepository = new CESRepository();
            reg = new Registration();
        }
        public ActionResult Estimate()
        {
            //Session["unitcost"] = 0;
            return View();
        }
        [HttpPost]
        public ActionResult Estimate(FormCollection fc)
        {
            cartonPriceEstimator estimator = new cartonPriceEstimator();
            TempData["trade"] = fc["trade"];
            TempData["companyName"] = fc["companyName"];
            TempData["dimension"] = fc["dimension"];
            TempData["quantity"] = int.Parse(fc["quantity"]);
            TempData["material"] = fc["material"];
            TempData.Keep("trade");
            TempData.Keep("companyName");
            TempData.Keep("dimension");
            TempData.Keep("quantity");
            TempData.Keep("material");
            //TempData["unitcost"] = TempData["unitcost"];

            return RedirectToAction("GetQuotation","Quotation");
        }
        public ActionResult MyOrders()
        {
            string username = User.Identity.Name;
            string buyername = reg.GetBuyerName(username);
            List<quotation> quotations = cesRepository.GetBuyerQuotations(buyername);
            List<Quotation> qmodel = new List<Quotation>();
            foreach(var item in quotations)
            {
                Quotation q = new Quotation();
                q.buyer_id = item.buyer_id;
                q.seller_id = item.seller_id;
                q.buyer_name = item.buyer_name;
                q.seller_name = item.seller_name;
                q.trade = item.trade;
                q.material = item.material;
                q.dimension = item.dimension;
                q.quantity = item.quantity;
                q.unit_cost = item.unit_cost;
                q.company = item.company;
                qmodel.Add(q);
            }
            return View(qmodel);
        }
       
    }
}