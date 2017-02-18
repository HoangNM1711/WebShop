using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Nhập tên đăng nhập")]
        public string Username { get; set; }

        [Display(Name="Mật khẩu")]  
        [Required(ErrorMessage ="Nhập mật khẩu")]
        [StringLength(maximumLength:20,MinimumLength =6,ErrorMessage ="Mật khẩu ít nhất 6 ký tự")]
        public string Password { get; set; }

        [Display(Name="Nhập lại mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu không trùng khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Nhập họ tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Nhập Email")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Nhập Điện thoại")]
        public string Phone { get; set; }
    }
}