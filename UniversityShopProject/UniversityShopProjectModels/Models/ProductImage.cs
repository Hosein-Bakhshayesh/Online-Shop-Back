﻿using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class ProductImage:BaseEntity
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
