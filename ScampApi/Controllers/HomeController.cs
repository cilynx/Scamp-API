using Microsoft.AspNet.Mvc;
using Microsoft.Framework.ConfigurationModel;
using ScampApi.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ScampApi.Controllers
{
    public class HomeController : Controller
    {

        IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var settings = new ScampSettings
            {
                TenantId = _config.Get("TenantId"),
                ClientId = _config.Get("ClientId"),
                RedirectUri = _config.Get("RedirectUri"),
                CacheLocation = _config.Get("CacheLocation"),
                
            };

            return View(settings);
        }
    }
}

