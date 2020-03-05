using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPool.Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPool.Controllers
{
    public class RouteController : Controller
    {

        [Route("/")]
        [Route("/Find")]
        public IActionResult FindRouteForm(Route r, string ReturnUrl)
        {
           ModelState.Clear(); // zamezi zobrazeni validačni hlašky po prvním spuštení
            return View("FindRouteForm");
        }

        public IActionResult FindRoute(Route route)
        {

            if (!ModelState.IsValid)
                return View("FindRouteForm");
          

            List<Route> routes = new List<Route>();
            route.date = route.date.Add(route.time.TimeOfDay);


            using (var db = new RoutesContext())
            {
                var query = from ro in db.Routes
                            where route.date.AddMinutes(-30) <= ro.date && ro.date <= route.date.AddMinutes(30)
                            && route.startDest == ro.startDest && route.finalDestination == ro.finalDestination
                            select ro;

                foreach (Route r in query)
                {
                    routes.Add(r);
                }

            }

            ViewData["Routes"] = routes;


            return View("FindRouteResolutTable");
        }

        public IActionResult AddRouteToDB(Route route)
        {
            using (var cpx = new RoutesContext())
            {
                route.date = route.date.Add(route.time.TimeOfDay);
                cpx.Routes.Add(route);
                cpx.SaveChanges();
            }



            return View("CreateRouteForm");




        }

        [Route("/Create")]
        [Authorize]
        public IActionResult CreateRouteForm()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("/Route/ShowDetail")]
        public IActionResult ShowDetail(int id)
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    


    }
}