using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess
{
    public class AccountDAO : SingletonBase<AccountDAO>
    {
        public async Task<IEnumerable<Account>> GetAllAccount() => await _context.Accounts.Include(a => a.Role).ToListAsync();

        public async Task<Account?> GetAccountById(int id)
        {
            try
            {
                var account = await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.AccountId == id);
                if (account == null)
                {
                    return null;
                }
                return account;
            }
            catch (Exception ex) {
                throw new Exception("(AccountDAO) Get Account By Id Error: " + ex.Message);
            }
            
        }

        public async Task<Account> CreateAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return account;
            }
            catch (Exception ex) {
                throw new Exception("(AccountDAO) Create Account Error: " + ex.Message);
            }
            
        }

        public async Task<Account?> UpdateAccount(Account account)
        {
            try
            {
                var accountUpdate = GetAccountById(account.AccountId);
                if (accountUpdate != null)
                {
                    _context.Entry(accountUpdate).CurrentValues.SetValues(account);
                    await _context.SaveChangesAsync();
                    return account;
                }
                return null;
            }catch (Exception ex) {
                throw new Exception("(AccountDAO) Update Account Error: " + ex.Message);
            }
            
        }

        public async Task DeleteAccount(int id)
        {
            try
            {
                var accountDelete = await GetAccountById(id);
                if (accountDelete != null)
                {
                    _context.Accounts.Remove(accountDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("(AccountDAO) Delete Account Error: " + ex.Message);
            }
        }
    }
}
