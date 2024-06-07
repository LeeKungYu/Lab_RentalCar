using System;
using System.Collections.Generic;

namespace Infrastructure.RentalCar;

public partial class Account
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? Password { get; set; }

    public string? Aid { get; set; }

    public string? MobilePhone { get; set; }

    public string? ChtName { get; set; }
}
