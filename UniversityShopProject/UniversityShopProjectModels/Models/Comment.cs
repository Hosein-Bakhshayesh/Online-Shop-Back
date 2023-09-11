using System;
using System.Collections.Generic;

namespace UniversityShopProjectModels.Models;

public partial class Comment : BaseEntity
{
    public int CommentId { get; set; }

    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string CommentText { get; set; } = null!;

    public string DateTime { get; set; } = null!;

    public int Like { get; set; }

    public bool IsActive { get; set; }

    public virtual Product Product { get; set; } = null!;
}
