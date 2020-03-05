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
using CarPool.Data;
using System.ComponentModel.DataAnnotations;
using ExternalData.Models;

namespace CarPool.Controllers
{
   
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("/Find")]
        public IActionResult Find(Route r ,string ReturnUrl)
        {

            ModelState.Clear(); // zamezi zobrazeni validačni hlašky po prvním spuštení



            return View();
        }

        public IActionResult FindRoute(Route route)
        {

            if (!ModelState.IsValid)
                return View("Find");

            List < Route >routes= new List<Route>();
            route.date = route.date.Add(route.time.TimeOfDay);



            using (var db = new RoutesContext())
            {
                var query = from ro in db.Routes
                            where route.date.AddMinutes(-30) <= ro.date && ro.date<= route.date.AddMinutes(30)
                            && route.startDest==ro.startDest && route.finalDestination==ro.finalDestination
                            select ro;

                foreach (Route r in query)
                {
                    routes.Add(r);
                }


            }




            //  PSSQLControll DB = new PSSQLControll();

            ViewData["Routes"] = routes;


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
            using (var cpx=new RoutesContext())
            {
               route.date= route.date.Add(route.time.TimeOfDay);
                cpx.Routes.Add(route);
                cpx.SaveChanges();
            }



            return View("Create");




        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
