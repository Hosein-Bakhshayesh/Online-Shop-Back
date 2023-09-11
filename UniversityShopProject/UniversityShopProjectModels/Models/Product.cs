using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class Product : BaseEntity
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductImagePath { get; set; } = null!;

    public string ProductDiscription { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Price { get; set; } = null!;

    public int Number { get; set; }

    public bool IsActive { get; set; }

    public int? Views { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
