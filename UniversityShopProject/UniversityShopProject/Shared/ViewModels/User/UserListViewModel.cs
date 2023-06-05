using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.User
{
    public class UserListViewModel
    {
        [Key]
        [Display(Name = "آیدی")]
        public int UserId { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string UserName { get; set; } = null!;
        [Display(Name = "نام")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string LastName { get; set; } = null!;
        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }
        public string InfoUrl { get; set; }
    }
}
