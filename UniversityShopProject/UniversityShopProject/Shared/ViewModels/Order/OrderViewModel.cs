using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Order
{
    public class OrderViewModel
    {
        [Key]
        [DisplayName("آیدی")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("کاربر")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("نام")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("شماره موبایل")]
        public string Mobile { get; set; } = null!;
        [DisplayName("ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("استان")]
        public int ProvinceId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("شهر")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("خیابان")]
        public string Street { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("پلاک")]
        public int Pelak { get; set; }
        [DisplayName("واحد")]
        public int? Vahed { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("کد پستی")]
        public string PostalCode { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("تاریخ")]
        public string Date { get; set; } = null!;

        [DisplayName("جزئیات")]
        public string? Detail { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("مجموع")]
        public string Total { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("وضعیت")]
        public string Status { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("فعال/غیرفعال")]
        public bool IsActive { get; set; }
    }
}
