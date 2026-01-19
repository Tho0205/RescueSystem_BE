using System;
using System.Collections.Generic;

namespace RescueSyetem_BE.Models;

public partial class Team
{
    public Guid TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Location { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lng { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();

    public virtual TeamMember? TeamMember { get; set; }
}
