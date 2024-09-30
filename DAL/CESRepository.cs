using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CESRepository
    {
        CES_DbContext context;
        public CESRepository()
        {
            context = new CES_DbContext();
        }
        public bool saveEstimatedCost(cartonPriceEstimator cpe)
        {
            context.cartonPriceEstimators.Add(cpe);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool saveQuotation(quotation q)
        {
            context.quotations.Add(q);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else { return false; }
        }

        public List<quotation> GetBuyerQuotations(string buyername)
        {
            return context.quotations.Where(y=>y.buyer_name == buyername).ToList();
        }
        public List<quotation> GetSellerQuotations(string sellername)
        {
            return context.quotations.Where(y => y.seller_name == sellername).ToList();
        }

        public List<seller> GetAllSellers()
        {
            return context.sellers.ToList();
        }
        public List<buyer> GetAllBuyers()
        {
            return context.buyers.ToList();
        }
       
    }
}
