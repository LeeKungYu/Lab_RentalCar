using Application.RentalCar;
using Application.RentalCar.ViewModels;
using Domain.RentalCar;

namespace Infrastructure.RentalCar
{
    public class RentalCarRepository : IQueryRentalCarUseCase
    {
        private readonly SaleCarDbContext _context;

        public RentalCarRepository(SaleCarDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AccountViewModel> GetAllAccounts()
        {
            var result = from account in _context.Accounts
                         select new AccountViewModel()
                         {
                             Id = account.Id,
                             UserId = account.UserId,
                             Password = account.Password,
                             Aid = account.Aid,
                             MobilePhone = account.MobilePhone,
                             ChtName = account.ChtName,
                         };

            return result;
        }

        public IEnumerable<IVehicle> GetAllCars()
        {
            var result = _context.Cars.ToList();

            return new List<IVehicle>();
        }
    }
}
