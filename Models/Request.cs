using System;
using System.Collections.Generic;

namespace RescueSyetem_BE.Models;

public partial class Request
{
    public Guid RequestId { get; set; }

    public Guid CitizenId { get; set; }

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public decimal? Lat { get; set; }

    public decimal? Lng { get; set; }

    public string? ImageUrl { get; set; }

    public int NumPeople { get; set; }

    public int DistType { get; set; }

    public int Urgency { get; set; }

    public string Status { get; set; } = null!;

    public DateTime RequestTime { get; set; }

    public DateTime? CompleteTime { get; set; }

    public string? Notes { get; set; }

    public virtual User Citizen { get; set; } = null!;

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
