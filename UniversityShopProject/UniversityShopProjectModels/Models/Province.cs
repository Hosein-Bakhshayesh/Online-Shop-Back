using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class Province : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<County> Counties { get; set; } = new List<County>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
