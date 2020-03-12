using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarPool.Data;
using CarPool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPool.Controllers
{
    public class RouteController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public RouteController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        private string GetUsername()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            return userId.ToString();

        }

        [Route("/")]
        [Route("/Find")]
        public IActionResult FindRouteForm(Route r, string ReturnUrl)
        {
            ModelState.Clear(); // zamezi zobrazeni validačni hlašky po prvním spuštení
                                //  return View("Clear");
            return View("FindRouteForm");
        }


        [HttpGet]
        public IActionResult FindRoute(Route route)
        {

            if (!ModelState.IsValid)
                return View("FindRouteForm");

            route.date = route.date.Add(route.time.TimeOfDay);


            List<Route> routes = new List<Route>();
            Route r = new Route();




            using (var db = new RoutesContext())
            {
                var query = from ro in db.Routes
                            where route.startDestination == ro.startDestination && route.finalDestination == ro.finalDestination
                            select ro;

                //Select route is 1h horizont
                foreach (Route routeFromQuery in query)
                {
                    if (route.date.AddMinutes(-30).Ticks <= routeFromQuery.date.Ticks && routeFromQuery.date.Ticks <= route.date.AddMinutes(30).Ticks)
                        routes.Add(routeFromQuery);
                }

                //Mark allready joined routes
                var selectedroutes = db.routeUsers.Where(ru => ru.UserId == GetUsername());
                foreach (RouteUser selrout in selectedroutes)
                {

                    r = routes.Where(ro => ro.id == selrout.RoutId).FirstOrDefault();
                    if (r != null)
                        r.connected = true;
                }

            }

            ViewData["Routes"] = routes;
            ViewBag.FindingRoute = route;


            return View("FindRouteResolutTable");
        }


        public IActionResult AddRouteToDB(Route route)
        {
            using (var cpx = new RoutesContext())
            {
                


                route.date = route.date.Add(route.time.TimeOfDay);
                route.createdBy = userManager.GetUserName(User);
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
            Route routeFromDb = new Route();

            using (var db = new RoutesContext())
            {
                routeFromDb = db.Routes.Where(r => r.id == id).FirstOrDefault();

            }


            return View(routeFromDb);
        }


        [HttpPost]
        [Route("/Route/JoinRoute")]
        public void JoinRoute(int id)
        {
            ViewData["Message"] = "Your application description page.";
            Route routeFromDb = new Route();

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;


            using (var routesdb = new RoutesContext())
            {
                routesdb.Add(new RouteUser { RoutId = id, UserId = userId });
                routesdb.SaveChanges();


            }


        }


        [Route("/Route/Logged")]
        public IActionResult ShowLoggedRoutes()
        {
            List<Route> myRoutes = new List<Route>();


            using (var routeContext = new RoutesContext())
            {
                var query = from RouteUser in routeContext.routeUsers
                            join route in routeContext.Routes on RouteUser.RoutId equals route.id
                            where RouteUser.UserId == GetUsername() && route.id == RouteUser.RoutId
                            select route;


                foreach (Route routeFromQuery in query)
                {
                    routeFromQuery.connected = true;
                    myRoutes.Add(routeFromQuery);
                }

            }

            ViewData["Routes"] = myRoutes;

            return View("FindRouteResolutTable");

        }


        [Route("/Route/My")]
        public IActionResult ShowMyRoutes()
        {

        



            return View("FindRouteResolutTable");

        }

    }
}