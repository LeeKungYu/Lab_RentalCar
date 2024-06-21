using Application.RentalCar;
using Application.RentalCar.ViewModels;
using EasyArchitectCore.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Web.RentalCar.Utility.CookieHelper;

namespace Web.RentalCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly RentalCarService _rentalCarService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public AccountController(
            RentalCarService rentalCarService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _rentalCarService = rentalCarService;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        [Authorize]
        public IActionResult Index()
        {
            var accountList = _rentalCarService.GetAllAccounts();
            return View(accountList);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                if (account.UserId == "Nick")
                {
                    if (ProcessLogin(account))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult RunLogout()
        {
            _httpContextAccessor.HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// 註冊帳號
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        protected virtual bool ProcessLogin(AccountViewModel? account)
        {
            bool result = true;
            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[2]
            {
                new Claim("name", account.UserId),
                new Claim("role", "Admin")
            }, "Cookies"));
            try
            {
                _httpContextAccessor.HttpContext.SignInAsync(principal);
                int value = _configuration.GetSection("AppSettings").GetValue<int>("TimeoutMinutes");
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(value),
                    HttpOnly = true
                };
                NewCookie newCookie = new NewCookie(UserInfo.LOGIN_USER_INFO);
                newCookie.Values.Add("Username", account.UserId);
                string jsonByNewCookie = NewCookie.GetJsonByNewCookie(newCookie);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(UserInfo.LOGIN_USER_INFO, jsonByNewCookie, options);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
