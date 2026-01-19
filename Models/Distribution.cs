using System;
using System.Collections.Generic;

namespace RescueSyetem_BE.Models;

public partial class Distribution
{
    public Guid DistId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<DistDetail> DistDetails { get; set; } = new List<DistDetail>();

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
