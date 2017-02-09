using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]

        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAllCategory();

            return PartialView(model);
        }

        public ActionResult Category(long categoryId)
        {
            var category = new CategoryDAO().ViewDetail(categoryId);
            return View(category);
        }

        public ActionResult Detail(long productId)
        {
            var product = new ProductDAO().ViewDetail(productId);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProduct = new ProductDAO().ListRelatedProduct(productId);
            return View(product);
        }
    }
}