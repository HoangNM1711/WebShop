using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContentDAO
    {
        WebShop db = null;

        public ContentDAO()
        {
            db = new WebShop();
        }

        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
    }
}
