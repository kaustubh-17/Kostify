using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES.Models
{
    public class cartonPriceEstimatorModel
    {
        public int carton_id { get; set; }
        public string product { get; set; }
        public string company { get; set; }
        public string dimension { get; set; }
        public int quantity { get; set; }
        public double unitcost { get; set; }
        public string material { get; set; }
    }
}