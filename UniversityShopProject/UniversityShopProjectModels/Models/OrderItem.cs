using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class OrderItem : BaseEntity
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public string Total { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
