using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.RentalCar;

[Table("Car")]
public partial class CarEntity
{
    public int? Id { get; set; }

    public string? Model { get; set; }

    public int? Cc { get; set; }

    public DateTime? ManufacturingDate { get; set; }

    public string? Type { get; set; }
}
