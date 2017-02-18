using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Login
    {
        [Key]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Nhập tên đăng nhập")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="Nhập mật khẩu")]
        public string Password { get; set; }
    }
}