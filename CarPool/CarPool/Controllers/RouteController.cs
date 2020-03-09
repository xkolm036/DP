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
        [HttpGet]
        public IActionResult FindRoute(Route r)
        {

            if (!ModelState.IsValid)
                return View("FindRouteForm");

            r.date = r.date.Add(r.time.TimeOfDay);

          
            List<Route> routes = new List<Route>();
          //  route.date = route.date.Add(route.time.TimeOfDay);


            using (var db = new RoutesContext())
            {
                var query = from ro in db.Routes
                            where r.startDestination == ro.startDestination && r.finalDestination == ro.finalDestination
                       
                            select ro;

                foreach (Route routeFromQuery in query)
                {
                    if (r.date.AddMinutes(-30).Ticks <= routeFromQuery.date.Ticks && routeFromQuery.date.Ticks <= r.date.AddMinutes(30).Ticks)
                    routes.Add(routeFromQuery);
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
            Route routeFromDb=new Route();

            using (var db = new RoutesContext())
            {
               routeFromDb= db.Routes.Where(r => r.id == id).FirstOrDefault();

            }




            return View(routeFromDb);
        }
    


    }
}