using Domain.RentalCar;

namespace Application.RentalCar
{
    /// <summary>
    /// Appication Services 應用層的 RentalCarServices 租車服務
    /// </summary>
    public class RentalCarService
    {
        private readonly IQueryRentalCarUseCase _queryRentalCarUseCase;

        public RentalCarService(IQueryRentalCarUseCase queryRentalCarUseCase)
        {
            _queryRentalCarUseCase = queryRentalCarUseCase;
        }

        public IEnumerable<IVehicle> GetAllCars()
        {
            return _queryRentalCarUseCase.GetAllCars();
        }

        public TimeSpan ChoiseRentalTime(DateTime start, DateTime end)
        {
            return TimeSpan.FromSeconds(1);
        }

        public decimal CalculateRentalCost(int daysRented, VehicleType vehicleType)
        {
            var result = _queryRentalCarUseCase.GetAllCars()
                .Where(c => c.GetVehicleType() == vehicleType)
                .FirstOrDefault();

            return result!.CalculateRentalCost(daysRented);
        }



    }
}
