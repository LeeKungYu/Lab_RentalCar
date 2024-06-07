using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RentalCar
{
    public interface IVehicle
    {
        /// <summary>
        /// 計算租車費用
        /// </summary>
        /// <param name="daysRented"></param>
        /// <returns></returns>
        decimal CalculateRentalCost(int daysRented);

        /// <summary>
        /// 選擇租車時間
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        TimeSpan ChoiceRentalTime(DateTime start, DateTime end);

        /// <summary>
        /// 取得車輛類型
        /// </summary>
        /// <returns></returns>
        VehicleType GetVehicleType();

    }
}
