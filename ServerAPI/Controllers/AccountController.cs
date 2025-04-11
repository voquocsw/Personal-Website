using BussinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        // GET: api/<AccountController>
        [HttpGet]
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
        public async Task<Account?> UpdateAccount(Account account)
        {
            return await accountRepository.UpdateAccount(account);
        }

        [HttpPost]
        public async Task<Account> CreateAccount(Account account)
        {
            return await accountRepository.CreateAccount(account);
        }
    }
}
