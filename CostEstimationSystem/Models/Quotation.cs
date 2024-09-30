using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostEstimationSystem.Models
{
    public class Quotation
    {
        public int quotation_id { get; set; }
        public string trade { get; set; }
        public string company { get; set; }
        public string material { get; set; }
        public string seller_name { get; set; }
        public string buyer_name { get; set; }
        public string dimension { get; set; }
        public int quantity { get; set; }
        public double unit_cost { get; set; }
        public int buyer_id { get; set; }
        public int seller_id { get; set; }

        public virtual buyer buyer { get; set; }
        public virtual seller seller { get; set; }
    }
}
