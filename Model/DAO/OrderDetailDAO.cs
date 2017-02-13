using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDetailDAO
    {
        WebShop db = null;

        public OrderDetailDAO()
        {
            db = new WebShop();
        }

        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();

                return true;
            }catch
            {
                return false;
            }
        }
    }
}
