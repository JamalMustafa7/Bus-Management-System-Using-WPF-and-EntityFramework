using System;
using System.Collections.Generic;

namespace EAD_Final_Project.Models;

public partial class Vehicle
{
    public string NumberPlateNumber { get; set; } = null!;

    public string ChasisNumber { get; set; } = null!;

    public string VType { get; set; } = null!;

    public short YearOfRegistration { get; set; }

    public virtual ICollection<VehicleEntry> VehicleEntries { get; set; } = new List<VehicleEntry>();
}
