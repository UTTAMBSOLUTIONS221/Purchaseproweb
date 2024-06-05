using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Purchaseproweb.Models;
using Purchaseproweb.Services;

namespace Purchaseproweb.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly Wemanageservices bl;
        public HomeController(IConfiguration config)
        {
            bl = new Wemanageservices(config);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}