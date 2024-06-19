using Application.RentalCar;
using Microsoft.AspNetCore.Mvc;

namespace Web.RentalCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly RentalCarService _rentalCarService;
        public AccountController(RentalCarService rentalCarService)
        {
            _rentalCarService = rentalCarService;
        }
        public IActionResult Index()
        {
            var accountList = _rentalCarService.GetAllAccounts();
            return View(accountList);
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
