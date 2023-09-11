using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد.")]
        [MinLength(8, ErrorMessage = "پسورد حداقل باید شامل 8 کاراکتر باشد.")]
        [DisplayName("پسورد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("به یاد داشته باش")]
        public bool RememberMe { get; set; }
    }
}
