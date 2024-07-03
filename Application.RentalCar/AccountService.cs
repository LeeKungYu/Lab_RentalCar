using Application.RentalCar.Repositories;
using Application.RentalCar.ViewModels;
using Common.RentalCar.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RentalCar
{
    /// <summary>
    /// 登入驗證相關服務
    /// </summary>
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool RegisterAccount(AccountViewModel account)
        {
            return _accountRepository.CreateAccount(account) > 0;
        }

        /// <summary>
        /// 驗證登入帳號密碼
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool ValidationAccount(AccountViewModel account)
        {
            bool result = false;

            AccountViewModel accountViewModel = _accountRepository.GetAccount(account.UserId);

            if (accountViewModel != null)
            {
                //比對密碼是否符合
                result = StringEncryptor.EncryptString(account.Password) == accountViewModel.Password;
            }

            return result;

        }

    }
}
