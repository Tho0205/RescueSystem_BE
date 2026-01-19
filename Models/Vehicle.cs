using System;
using System.Collections.Generic;

namespace RescueSyetem_BE.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
