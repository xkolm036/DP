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

        public IActionResult FindRoute(string startDestination, string finalDestination, string date, string time)
        {
            //Convert string to datetime
            DateTime dateTime = DateTime.Parse(date);
            DateTime times = DateTime.Parse(time);
            dateTime= dateTime.Add(times.TimeOfDay);


            if (!ModelState.IsValid)
                return View("FindRouteForm");



          
            List<Route> routes = new List<Route>();
          //  route.date = route.date.Add(route.time.TimeOfDay);


            using (var db = new RoutesContext())
            {
                var query = from ro in db.Routes
                            where dateTime.AddMinutes(-30) <= ro.date && ro.date <= dateTime.AddMinutes(30)
                            && startDestination == ro.startDestination && finalDestination == ro.finalDestination
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
            Route routeFromDb=new Route();

            using (var db = new RoutesContext())
            {
               routeFromDb= db.Routes.Where(r => r.id == id).FirstOrDefault();

            }




            return View(routeFromDb);
        }
    


    }
}