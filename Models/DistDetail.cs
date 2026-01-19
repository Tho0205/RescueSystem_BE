using System;
using System.Collections.Generic;

namespace RescueSyetem_BE.Models;

public partial class DistDetail
{
    public Guid DistId { get; set; }

    public int ItemId { get; set; }

    public decimal Quantity { get; set; }

    public virtual Distribution Dist { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
