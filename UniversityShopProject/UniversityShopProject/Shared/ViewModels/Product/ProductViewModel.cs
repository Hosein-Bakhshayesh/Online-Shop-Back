using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Product
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی میباشد")]
        public string ProductName { get; set; } = null!;
        public string ProductImagePath { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} الزامی میباشد")]
        public string ProductDiscription { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} الزامی میباشد")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی میباشد")]
        public string Price { get; set; } = null!;
        [Required(ErrorMessage = "فیلد {0} الزامی میباشد")]
        public int Number { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی میباشد")]
        public bool IsActive { get; set; }

        public string infoUrl { get; set; }
        public string? ProductDetailLink { get; set; }

    }
}
