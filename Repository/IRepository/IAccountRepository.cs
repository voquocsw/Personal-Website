using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccount();
        Task<Account?> GetAccountById(int id);
        Task<Account?> CreateAccount(Account account);
        Task<Account?> UpdateAccount(int id, Account account);
        Task DeleteAccount(int id);
    }
}
