using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Order
{
    public class OrderItemViewModel
    {
        [Key]
        [DisplayName("آیدی")]
        public int OrderItemId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("آیدی فاکتور")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("محصول")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("تعداد")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("مجموع")]
        public string Total { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("فعال/غیرفعال")]
        public bool IsActive { get; set; }
    }
}
