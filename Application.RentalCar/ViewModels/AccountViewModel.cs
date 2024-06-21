using System.ComponentModel.DataAnnotations;

namespace Application.RentalCar.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        public string? UserId { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        public string? Password { get; set; }

        public string? Aid { get; set; }

        public string? MobilePhone { get; set; }

        public string? ChtName { get; set; }
    }
}