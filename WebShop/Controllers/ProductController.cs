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

        public ActionResult Category(long categoryId, int pageIndex = 1 , int pageSize = 2)
        {
            var category = new CategoryDAO().ViewDetail(categoryId);
            ViewBag.Category = category;
            var model = new ProductDAO().ListByCategoryId(categoryId);
            return View(model);
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