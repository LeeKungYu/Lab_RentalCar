using System;
using System.Collections.Generic;

namespace Infrastructure.RentalCar;

public partial class Car
{
    public int? Id { get; set; }

    public string? Model { get; set; }

    public int? Cc { get; set; }

    public DateTime? ManufacturingDate { get; set; }

    public string? Type { get; set; }
}
