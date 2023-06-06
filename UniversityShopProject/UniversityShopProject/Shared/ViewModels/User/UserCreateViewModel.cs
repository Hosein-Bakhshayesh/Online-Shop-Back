using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.User
{
    public class UserCreateViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string UserName { get; set; } = null!;
        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="{0} باید حداقل 8 کاراکتر باشد")]
        public string Password { get; set; } = null!;
        [Display(Name = "تکرار پسورد")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "پسورد و تکرار آن یکسان نیست.")]
        public string RePassword { get; set; } = null!;
        [Display(Name = "نام")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string LastName { get; set; } = null!;
        [Display(Name = "شماره موبایل")]
        [MaxLength(11, ErrorMessage = "{0} اشتباه وارد شده است")]
        [MinLength(11, ErrorMessage = "{0} اشتباه وارد شده است")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string MobileNumber { get; set; } = null!;
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} درست وارد نشده است.")]
        public string? Email { get; set; }
        [Display(Name = "کد ملی")]
        public string? NationalCode { get; set; }
        [Display(Name = "جنسیت")]
        public bool? Gender { get; set; }
        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

    }
}
