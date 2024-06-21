using Application.RentalCar.Repositories;
using Application.RentalCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RentalCar
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CreateAccount(AccountViewModel account)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int EditAccount(AccountViewModel account)
        {
            throw new NotImplementedException();
        }
    }
}
