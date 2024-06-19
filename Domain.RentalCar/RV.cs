using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RentalCar
{
    /// <summary>
    /// 休旅車
    /// </summary>
    public class RV : IVehicle
    {
        public string Model { get; set; }
        public string CC { get; set; }

        public decimal CalculateRentalCost(int daysRented)
        {
            return daysRented * 120;
        }

        public TimeSpan ChoiceRentalTime(DateTime start, DateTime end)
        {
            return end - start;
        }

        public VehicleType GetVehicleType() => VehicleType.RV;
    }
}
