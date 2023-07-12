using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        [DisplayName("آیدی")]
        public int CategoryId { get; set; }
        [DisplayName("نام دسته‌بندی")]
        [Required(ErrorMessage ="فیلد {0} نباید خالی باشد.")]
        public string CategoryName { get; set; } = null!;
        [DisplayName("دسته اصلی")]
        public int? ParentId { get; set; }
        [DisplayName("وضعیت")]
        [Required(ErrorMessage = "فیلد {0} نباید خالی باشد.")]
        public bool IsActive { get; set; }
        public string? CInfoUrl { get; set; }
        public string? CAttributeUrl { get; set; }
        public string CImage { get; set; }
        public string PUrl { get; set; }
    }
}
