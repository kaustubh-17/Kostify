using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CostEstimationSystem.Models
{
    public class Estimator
    {
        public int carton_id { get; set; }
        public string trade { get; set; }
        public string companyName { get; set; }
        public string dimension { get; set; }
        public int quantity { get; set; }
        public double unitCost { get; set; }
        public string material { get; set; }
        public enum Materialx
        {
           
            Select,
            Cardboard,
            Paperboard,
            Plastic,
            Wood,
            Shrinkwrap,
            Bubblewrap,
            Stretchwrap,
            Steel,
            Aluminium,
            Fiberboard,
            Kraftpaper
        }
    }
}