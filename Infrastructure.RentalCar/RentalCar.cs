using System;
using System.Collections.Generic;

namespace Infrastructure.RentalCar;

public partial class RentalCar
{
    public int Id { get; set; }

    public string? CarType { get; set; }

    public DateTime? RentalStartTime { get; set; }

    public DateTime? RentalEndTime { get; set; }

    public int? AccountId { get; set; }
}
