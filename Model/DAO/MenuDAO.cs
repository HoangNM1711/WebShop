using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDAO
    {
        WebShop db = null;
        public MenuDAO()
        {
            db = new WebShop();
        }

        public List<Menu> ListByGroup(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
