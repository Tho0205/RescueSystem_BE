using System;
using System.Collections.Generic;

namespace RescueSyetem_BE.Models;

public partial class Mission
{
    public Guid MissionId { get; set; }

    public Guid RequestId { get; set; }

    public Guid TeamId { get; set; }

    public int? VehicleId { get; set; }

    public Guid? DistributionId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Result { get; set; }

    public virtual Distribution? Distribution { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;

    public virtual Vehicle? Vehicle { get; set; }
}
