using Microsoft.AspNetCore.Mvc;
using SessionMVC850.Models;
using SessionMVC850.ModelView;
using System.Diagnostics;

namespace SessionMVC850.Controllers
{
    public class HomeController : Controller
    {

        // test pull
        // test pull2

        // test comment
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
