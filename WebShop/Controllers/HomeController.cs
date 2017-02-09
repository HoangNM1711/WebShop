using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideDAO().ListAll();
            var product = new ProductDAO();
            ViewBag.NewProduct = product.ListNewProduct(4);
            ViewBag.HotProduct = product.ListHotProduct(4);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult MainMenu()
        {
            var model = new MenuDAO().ListByGroup(1);
             
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult TopMenu()
        {
            var model = new MenuDAO().ListByGroup(2);

            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = new FooterDAO().GetFooter();

            return PartialView(model);
        }
    }
}