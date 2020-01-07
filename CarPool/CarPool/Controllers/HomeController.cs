using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarPool.Models;
using Data.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using CarPool.Areas.Identity.Pages.Account;

namespace CarPool.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("/Find")]
        public IActionResult Find(Route r ,string ReturnUrl)
        {

            ModelState.Clear(); // zamezi zobrazeni validačni hlašky po prvním spuštení

            if (ReturnUrl != null)
            {
                ViewData["Login"] = true;
            }


            return View();
        }

        public IActionResult FindRoute(Route r)
        {
            if (!ModelState.IsValid)
                return View("Find");

            SQLControll DB = new SQLControll();

            ViewData["Routes"] = DB.FindRoutes(r);


            return View();
        }

       
        public IActionResult test()
        {

            return PartialView("LoginModal");
        }


        [Route("/Create")]
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult CreateRoute(Route route)
        {
            SQLControll DB = new SQLControll();
            DB.CreateRoute(route);
            DB.CloseConnection();

            return View("Create");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
