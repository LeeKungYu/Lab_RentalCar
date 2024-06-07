using Application.RentalCar;
using Domain.RentalCar;

namespace Infrastructure.RentalCar
{
    public class RentalCarRepository : IQueryRentalCarUseCase
    {
        public IEnumerable<IVehicle> GetAllCars()
        {
            throw new NotImplementedException();
        }
    }
}
