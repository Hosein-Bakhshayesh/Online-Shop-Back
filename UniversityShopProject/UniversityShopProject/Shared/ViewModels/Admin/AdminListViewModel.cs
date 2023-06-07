using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Admin
{
    public class AdminListViewModel
    {
        [DisplayName("آیدی")]
        public int AdminId { get; set; }
        [DisplayName("نام کاربری")]
        public string UserName { get; set; } = null!;
        [DisplayName("نام")]
        public string FirstName { get; set; } = null!;
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; } = null!;
        [DisplayName(".ضعیت فعال/غیرفعال")]
        public bool IsActive { get; set; }
        public string? AdminInfoUrl { get; set; }
    }
}
