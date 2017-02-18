using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDAO
    {
        WebShop ws = null;
        public UserDAO()
        {
            ws = new WebShop();
        }
        
        public bool ChangeStatus(long id)
        {
            var user = ws.Users.Find(id);
            user.Status = !user.Status;
            ws.SaveChanges();
            return user.Status;
        }
        public long Insert (User entity) 
        {
            ws.Users.Add(entity);
            ws.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = ws.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.Phone = entity.Phone;

                ws.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var user = ws.Users.Find(id);
                ws.Users.Remove(user);
                ws.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
           
        }
        public User GetUserById(string username)
        {
            return ws.Users.SingleOrDefault(x=>x.UserName == username);
        }

        public User ViewDetail (int id)
        {
            return ws.Users.Find(id);
        }

        public IEnumerable<User> ListAll(string searchString,int page, int pageSize)
        {
           IQueryable<User> model = ws.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page,pageSize);
        }
        public int Login (string username, string password)
        {
            var result = ws.Users.SingleOrDefault(x => x.UserName == username);
            if (result == null)
            {
                return 0; /* Tài khoản ko tồn tại */
            }
            else
            {
               if (result.Status == false)
                {
                    return -1; /*Tài khoản bị khóa */
                }
               else
                {
                    if (result.Password == password)
                        return 1; /* Đăng nhập thành công */
                    else
                        return -2; /* Sai mật khẩu */
                }
            }
        }

        public bool CheckUserName(string username)
        {
            return ws.Users.Count(x => x.UserName == username) > 0;
        }

        public bool CheckEmail(string email)
        {
            return ws.Users.Count(x => x.Email == email) > 0;
        }
    }
}
