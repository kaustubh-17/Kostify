using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Registration
    {
        CES_DbContext context;
        public Registration()
        {
            context = new CES_DbContext();
        }
        public bool SignupBuyer(buyer b)
        {
            context.buyers.Add(b);
            return context.SaveChanges() > 0;
        }
        public buyer LoginBuyer(buyer b)
        {
            return context.buyers.Where(x => x.username == b.username).Where(y=>y.password == b.password).FirstOrDefault();
        }
        public bool SignupSeller(seller s)
        {
            context.sellers.Add(s);
            return context.SaveChanges() > 0;
        }
        public seller LoginSeller(seller s)
        {
            return context.sellers.Where(x => x.username == s.username).Where(y=>y.password == s.password).FirstOrDefault();
        }
        public string GetBuyerName(string username)
        {
            buyer b = context.buyers.Where(x => x.username == username).FirstOrDefault();
            if (b != null)
                return b.name;
            else
                return "";
        }
        public string GetSellerName(string username)
        {
            seller s = context.sellers.Where(x => x.username == username).FirstOrDefault();
            if (s != null)
                return s.name;
            else
                return "";
        }
        public bool ChangeCredentials(string username, string password)
        {
            buyer b = context.buyers.Where(x => x.username == username).FirstOrDefault();
            seller s = context.sellers.Where(x => x.username == username).FirstOrDefault();
            if (b != null)
            {
                b.username = username;
                b.password = password;
                return context.SaveChanges() > 0;
            }
            else if (s != null)
            {
                s.username = username;
                s.password = password;
                return context.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
