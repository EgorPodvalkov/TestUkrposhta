using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestUkrposhta.Models;

namespace TestUkrposhta.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController()
        { }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}