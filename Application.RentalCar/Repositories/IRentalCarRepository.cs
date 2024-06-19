using Application.RentalCar.ViewModels;
using Domain.RentalCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.RentalCar.Repositories
{
    /// <summary>
    /// IRepository 介面: 對租車系統的外部 Infrastructure 的操作
    /// </summary>
    public interface IRentalCarRepository
    {
        /// <summary>
        /// 確認租車
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        int SaveRentalCar(IVehicle vehicle);
        int SaveAccount(AccountViewModel account);
    }
}
