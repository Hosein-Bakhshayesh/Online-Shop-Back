using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class ProductAttribute:BaseEntity
{
    public int Paid { get; set; }

    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public virtual CategoryAttribute Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
