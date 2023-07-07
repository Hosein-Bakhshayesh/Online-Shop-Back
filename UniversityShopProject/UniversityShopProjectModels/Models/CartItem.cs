using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class CartItem : BaseEntity
{
    public int CartItemId { get; set; }

    public int ProductId { get; set; }

    public int CartId { get; set; }

    public int Quantity { get; set; }

    public string Total { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
