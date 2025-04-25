using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HttpClient _httpClient;
        protected readonly string AccountUrl;
        protected readonly string ProductUrl;
        protected readonly string OrderUrl;
        protected readonly string CategoryUrl;
        protected readonly string RoleUrl;
        protected readonly string CategoryProductUrl;
        protected readonly string OrderDetalsUrl;

        public BaseController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            var apiSettings = new ApiSettings();
            configuration.GetSection("ApiUrls").Bind(apiSettings);

            AccountUrl = apiSettings.AccountUrl;
            ProductUrl = apiSettings.ProductUrl;
            OrderUrl = apiSettings.OrderUrl;
            CategoryUrl = apiSettings.CategoryUrl;
            RoleUrl = apiSettings.RoleUrl;
            CategoryProductUrl = apiSettings.CategoryProductUrl;
            OrderDetalsUrl = apiSettings.OrderDetailsUrl;
        }
    }
}
