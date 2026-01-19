using System;
using System.Collections.Generic;

namespace RescueSyetem_BE.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public string? Unit { get; set; }

    public decimal Stock { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<DistDetail> DistDetails { get; set; } = new List<DistDetail>();
}
