using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class City : BaseEntity
{
    public int Id { get; set; }

    public int ProvinceId { get; set; }

    public int CountyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual County County { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Province Province { get; set; } = null!;
}
