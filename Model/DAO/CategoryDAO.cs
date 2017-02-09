using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryDAO
    {
        WebShop db = null;
        public CategoryDAO()
        {
            db = new WebShop();
        }

        public List<Category> ListAllCategory()
        {
            
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }            
    }
}
