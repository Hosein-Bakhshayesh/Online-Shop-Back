using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Product
{
    public class ProductAttributeViewModel
    {
        public int Paid { get; set; }

        public int ProductId { get; set; }
        [Required]
        public int AttributeId { get; set; }
        [Required]
        public string? Discription { get; set; }
    }
}
