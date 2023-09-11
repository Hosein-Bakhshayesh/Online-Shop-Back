using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class Cart : BaseEntity
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public string? Detail { get; set; }

    public string Total { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual User User { get; set; } = null!;
}
