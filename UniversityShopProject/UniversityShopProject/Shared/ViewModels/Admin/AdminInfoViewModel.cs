﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Admin
{
    public class AdminInfoViewModel
    {
        [DisplayName("آیدی")]
        public int AdminId { get; set; }
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string UserName { get; set; } = null!;
        [DisplayName("پسورد")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string Password { get; set; } = null!;
        [DisplayName("نام")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string FirstName { get; set; } = null!;
        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string LastName { get; set; } = null!;
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public string MobileNumber { get; set; } = null!;
        [DisplayName("ایمیل")]
        public string? Email { get; set; }
        [DisplayName(".ضعیت فعال/غیرفعال")]
        [Required(ErrorMessage = "پر کردن فیلد {0} الزامی است.")]
        public bool IsActive { get; set; }
        public string? EditUrl { get; set; }
    }
}
