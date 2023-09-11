using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class WishList : BaseEntity
{
    public int WishId { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
