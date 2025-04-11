using BussinessObject;
using DataAccess;
using Repository.IRepository;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<IEnumerable<Account>> GetAllAccount() => await AccountDAO.Instance.GetAllAccount();
        public async Task<Account?> GetAccountById(int id) => await AccountDAO.Instance.GetAccountById(id);
        public async Task<Account?> CreateAccount(Account account) => await AccountDAO.Instance.CreateAccount(account);
        public async Task<Account?> UpdateAccount(Account account) => await AccountDAO.Instance.UpdateAccount(account);
        public async Task DeleteAccount(int id) => await AccountDAO.Instance.DeleteAccount(id);
    }
}
