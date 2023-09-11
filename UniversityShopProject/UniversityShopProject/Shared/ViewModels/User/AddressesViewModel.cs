using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.User
{
    public class AddressesViewModel
    {
        [Key]
        [DisplayName("آیدی")]
        public int AddressId { get; set; }
        [DisplayName("کاربر")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی است.")]
        [DisplayName("استان")]
        public int Province { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی است.")]
        [DisplayName("شهر")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی است.")]
        [DisplayName("خیابان")]
        public string Street { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} الزامی است.")]
        [DisplayName("پلاک")]
        public int Pelak { get; set; }
        [DisplayName("واحد")]
        public int? Vahed { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی است.")]
        [DisplayName("کد پستی")]
        public string PostalCode { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} الزامی است.")]
        [DisplayName("نام")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} الزامی است.")]
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; } = null!;
        [DisplayName("شماره موبایل")]
        public string? Mobile { get; set; }
        public string? cityName { get; set; }
    }
}
