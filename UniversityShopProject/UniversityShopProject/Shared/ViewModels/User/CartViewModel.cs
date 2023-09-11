using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.User
{
    public class CartViewModel
    {
        [Key]
        [DisplayName("آیدی")]
        public int CartId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("کاربر")]
        public int UserId { get; set; }
        [DisplayName("توضیحات")]
        public string? Detail { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("مجموع")]
        public string Total { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("فعال/غیرفعال")]
        public bool IsActive { get; set; }

    }
}
