using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDAO
    {
        WebShop db = null;

        public OrderDAO()
        {
            db = new WebShop();
        }

        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();

            return order.ID;
        } 
    }
}
