using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityShopProject.Shared.ViewModels.Comment
{
    public class CommentViewModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را پر کنید.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "لطفا {0} را پر کنید.")]
        public string CommentText { get; set; } = null!;

        public string DateTime { get; set; } = null!;

        public int Like { get; set; }

        public bool IsActive { get; set; }
    }
}
