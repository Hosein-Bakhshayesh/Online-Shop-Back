using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class Address : BaseEntity
{
    public int AddressId { get; set; }

    public int UserId { get; set; }

    public int Province { get; set; }

    public int CityId { get; set; }

    public string Street { get; set; } = null!;

    public int Pelak { get; set; }

    public int? Vahed { get; set; }

    public string PostalCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Mobile { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Province ProvinceNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
