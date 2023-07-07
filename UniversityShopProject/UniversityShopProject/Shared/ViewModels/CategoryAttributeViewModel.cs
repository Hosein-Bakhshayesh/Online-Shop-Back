using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels
{
    public class CategoryAttributeViewModel
    {
        [DisplayName("آیدی")]
        public int AttributeId { get; set; }
        [DisplayName("آیدی دسته‌بندی")]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("عنوان")]
        public string Title { get; set; } = null!;
        [DisplayName("توضیحات")]
        public string? Discription { get; set; }
    }
}
