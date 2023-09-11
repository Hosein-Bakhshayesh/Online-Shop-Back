using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.User
{
    public class CartItemViewModel
    {
        [Key]
        [DisplayName("آیدی")]
        public int CartItemId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("کالا")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("سبد خرید")]
        public int CartId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("تعداد")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("مجموع")]
        public string Total { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("فعال")]
        public bool IsActive { get; set; }
    }
}
