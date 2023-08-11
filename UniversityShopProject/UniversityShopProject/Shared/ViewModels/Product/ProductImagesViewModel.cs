using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Product
{
    public class ProductImagesViewModel
    {
        public int ImageId { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; } = null!;
    }
}
