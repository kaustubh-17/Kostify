using CostEstimationSystem.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CostEstimationSystem.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        Registration reg;
        CESRepository cesRepository;
        CES_DbContext context;
        public SellerController()
        {
            reg = new Registration();
            cesRepository = new CESRepository();
            context = new CES_DbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyQuotations()
        {
            string username = User.Identity.Name;
            string sellername = reg.GetSellerName(username);
            List<quotation> quotations = cesRepository.GetSellerQuotations(sellername);
            List<Quotation> qmodel = new List<Quotation>();
            foreach (var item in quotations)
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
        public ActionResult Reject(int id)
        {
            
            quotation quotation = context.quotations.Where(u=>u.quotation_id == id).FirstOrDefault();
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }
        // POST: Customer/Delete/5
        [HttpPost, ActionName("Reject")]
        [ValidateAntiForgeryToken]
        public ActionResult RejectConfirmed(int id)
        {
            quotation quotation = context.quotations.Find(id);
            context.quotations.Remove(quotation);
            context.SaveChanges();
            return RedirectToAction("MyQuotations");
        }
    }
}