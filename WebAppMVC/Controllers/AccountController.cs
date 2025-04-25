using Azure;
using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WebAppMVC.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IConfiguration configuration) : base(configuration) { }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            var request = _httpClient.GetAsync($"{AccountUrl}?$filter=username eq '{Username}' and password eq '{Password}'").Result;
            if (!request.IsSuccessStatusCode)
            {
                ViewData["Notificate"] = "Username or Password is invalid";
                return View();
            }
            string responseData = await request.Content.ReadAsStringAsync();
            var account = JsonConvert.DeserializeObject<List<Account>>(responseData);

            if (account != null && account.Count > 0)
            {
                HttpContext.Session.SetString("account", JsonConvert.SerializeObject(account));
                return RedirectToAction("Index", "Home");
            }
            ViewData["Notificate"] = "Username or Password is invalid";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Account account)
        {

            var request = _httpClient.PostAsJsonAsync($"{AccountUrl}", account).Result;
            if (!request.IsSuccessStatusCode)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
    }
}
