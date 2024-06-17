using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Home()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    }
}
