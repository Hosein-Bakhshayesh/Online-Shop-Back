using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class County:BaseEntity
{
    public int Id { get; set; }

    public int ProvinceId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Province Province { get; set; } = null!;
}
