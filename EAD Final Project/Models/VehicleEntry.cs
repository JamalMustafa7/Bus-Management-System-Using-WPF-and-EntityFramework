using System;
using System.Collections.Generic;

namespace EAD_Final_Project.Models;

public partial class VehicleEntry
{
    public int Id { get; set; }

    public DateTime? In { get; set; }

    public DateTime? Out { get; set; }

    public string Status { get; set; } = null!;

    public string NumberPlateNumber { get; set; } = null!;

    public virtual Vehicle NumberPlateNumberNavigation { get; set; } = null!;
}
