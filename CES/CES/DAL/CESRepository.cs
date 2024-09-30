using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CESRepository
    {
        CostEstimationDbContext dbContext;
        public CESRepository()
        {
            dbContext = new CostEstimationDbContext();
        }

        public bool saveEstimatedCost(cartonPriceEstimator cpe_obj)
        {
            dbContext.cartonPriceEstimators.Add(cpe_obj);
            if(dbContext.SaveChanges()>0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
