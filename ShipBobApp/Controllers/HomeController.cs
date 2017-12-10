using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShipBobApp.Models;

namespace ShipBobApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Install()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult UseCase()
        {
            ViewData["Message"] = "Use Case Notes";

            return View();
        }

        public IActionResult Testing()
        {
            ViewData["Message"] = "Testing";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
