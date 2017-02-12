using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CartItemController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: CartItem
        public ActionResult Index()
        {
            var Cart = Session[CartSession];
            var list = new List<CartItem>();
            if (Cart != null)
            {
                list = (List<CartItem>)Cart;
            }
            return View(list);
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDAO().ViewDetail(productId);
            var Cart = Session[CartSession];
            if (Cart != null)
            {
                var list = (List<CartItem>)Cart;

                if(list.Exists(x=>x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    } 
                }
                else
                {
                    //Create Cart Item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
            }
            else
            {
                //Create Cart Item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}