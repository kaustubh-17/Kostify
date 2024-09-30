using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using CES.Models;
using System.Web.Routing;

namespace CES.Controllers
{
    public class CostEstimationController : Controller
    {
        CESRepository cESRepository;
        public CostEstimationController()
        {
            cESRepository = new CESRepository();
        }
        // GET: CostEstimation
        public ActionResult AddEstimatedCost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEstimatedCost(cartonPriceEstimatorModel cpem_obj)
        {
            cartonPriceEstimator cpe_obj = new cartonPriceEstimator();
            cpe_obj.carton_id= cpem_obj.carton_id;
            cpe_obj.product= cpem_obj.product;
            cpe_obj.company= cpem_obj.company;
            cpe_obj.dimension= cpem_obj.dimension;
            cpe_obj.quantity= cpem_obj.quantity;
            cpe_obj.unitcost= cpem_obj.unitcost;
            cpe_obj.material= cpem_obj.material;

            if(cESRepository.saveEstimatedCost(cpe_obj))
            {
                ViewBag.message = "Data Saved";
            }
            else { ViewBag.message = "Data not Saved"; }
            return View();
        }

    }
}