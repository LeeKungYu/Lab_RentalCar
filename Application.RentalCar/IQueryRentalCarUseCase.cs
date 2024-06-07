using Domain.RentalCar;

namespace Application.RentalCar
{
    public interface IQueryRentalCarUseCase
    {
        /// <summary>
        /// 查詢所有可租用車輛資料
        /// </summary>
        /// <returns></returns>
        IEnumerable<IVehicle> GetAllCars();
    }
}