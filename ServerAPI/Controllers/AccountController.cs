using BussinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repository;
using Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ODataController
    {
        private readonly IAccountRepository accountRepository;

        public AccountController()
        {
            accountRepository = new AccountRepository();
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Account>> GetAllAccount()
        {
             return await accountRepository.GetAllAccount();
        }

        [HttpGet("{id}")] 
        public async Task<Account?> GetAccountById(int id)
        {
            return await accountRepository.GetAccountById(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAccount(int id)
        {
            await accountRepository.DeleteAccount(id);
        }

        [HttpPut("{id}")] 
        public async Task<Account?> UpdateAccount(int id, Account account)
        {
            return await accountRepository.UpdateAccount(id, account);
        }

        [HttpPost]
        public async Task<Account> CreateAccount(Account account)
        {
            return await accountRepository.CreateAccount(account);
        }
    }
}
