using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class Order:BaseEntity
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string? Email { get; set; }

    public int ProvinceId { get; set; }

    public int CityId { get; set; }

    public string Street { get; set; } = null!;

    public int Pelak { get; set; }

    public int? Vahed { get; set; }

    public string PostalCode { get; set; } = null!;

    public string? Detail { get; set; }

    public string Total { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Province Province { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
