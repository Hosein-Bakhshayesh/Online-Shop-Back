using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class CategoryAttribute:BaseEntity
{
    public int AttributeId { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Discription { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}
