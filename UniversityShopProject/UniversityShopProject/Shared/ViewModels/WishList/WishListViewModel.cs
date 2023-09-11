using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.WishList
{
    public class WishListViewModel
    {
        [Key]
        [DisplayName("آیدی")]
        public int WishId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("محصول")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری است.")]
        [DisplayName("کاربر")]
        public int UserId { get; set; }
    }
}
