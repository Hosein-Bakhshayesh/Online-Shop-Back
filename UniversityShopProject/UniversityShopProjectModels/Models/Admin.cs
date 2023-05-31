using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class Admin:BaseEntity
{
    public int AdminId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string? Email { get; set; }

    public bool IsActive { get; set; }
}
