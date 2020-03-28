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



        [Route("/")]
        [Route("/Find")]
        [Route("/Home/Index")]
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
                            where route.startDestination == ro.startDestination && route.finalDestination == ro.finalDestination && ro.createdBy != userManager.GetUserName(User)
                            select ro;

                //Select route is 1h horizont
                foreach (Route routeFromQuery in query)
                {
                    if (route.date.AddMinutes(-30).Ticks <= routeFromQuery.date.Ticks && routeFromQuery.date.Ticks <= route.date.AddMinutes(30).Ticks)
                        routes.Add(routeFromQuery);
                }

                //Mark allready joined routes
                var selectedroutes = db.routeUsers.Where(ru => ru.UserId == userManager.GetUserId(User));
                foreach (RouteUser selrout in selectedroutes)
                {

                    r = routes.Where(ro => ro.id == selrout.RoutId).FirstOrDefault();
                    if (r != null)
                        r.connected = true;
                }

            }

            ViewData["Routes"] = routes;
            ViewData["Title"] = "Nalezené jízdy";
            if (routes.Count == 0)
                TempData["EmptyErrMessage"] = "Nebyly nalezeny žadné jízdy";
            //   ViewBag.FindingRoute = route;


            return View("FindRouteResolutTable");
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddRouteToDB(Route route)
        {
            using (var cpx = new RoutesContext())
            {

                route.date = route.date.Add(route.time.TimeOfDay);
                route.createdBy = userManager.GetUserName(User);
                cpx.Routes.Add(route);
                cpx.SaveChanges();
            }



            return View("AddRouteNextStep");




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

        [Authorize]
        [HttpPost]
        [Route("/Route/JoinRoute")]
        public void JoinRoute(int id)
        {
            using (var routesdb = new RoutesContext())
            {
                routesdb.Add(new RouteUser { RoutId = id, UserId = userManager.GetUserId(User) });
                routesdb.SaveChanges();


            }


        }

        [Authorize]
        [HttpPost]
        [Route("/Route/LeaveRoute")]
        public void LeaveRoute(int id)
        {
            ViewData["Message"] = "Your application description page.";
            Route routeFromDb = new Route();



            using (var routesdb = new RoutesContext())
            {
                var routeTodelete = routesdb.routeUsers.Where(ru => ru.RoutId == id && ru.UserId == userManager.GetUserId(User)).FirstOrDefault();
                routesdb.routeUsers.Remove(routeTodelete);
                routesdb.SaveChanges();
            }


        }

        [Authorize]
        [Route("/Route/Logged")]
        public IActionResult ShowLoggedRoutes()
        {
            List<Route> myRoutes = new List<Route>();


            using (var routeContext = new RoutesContext())
            {
                var query = from RouteUser in routeContext.routeUsers
                            join route in routeContext.Routes on RouteUser.RoutId equals route.id
                            where RouteUser.UserId == userManager.GetUserId(User) && route.id == RouteUser.RoutId
                            select route;


                foreach (Route routeFromQuery in query)
                {
                    routeFromQuery.connected = true;
                    myRoutes.Add(routeFromQuery);
                }

            }

            ViewData["Routes"] = myRoutes;
            ViewData["Title"] = "Přihlášené jízdy";

            if (myRoutes.Count == 0)
                TempData["EmptyErrMessage"] = "Dosud nejsi přihlášen k žadné jízdě";


            return View("FindRouteResolutTable");

        }

        [Authorize]
        [Route("/Route/My")]
        public IActionResult ShowMyRoutes()
        {
            List<Route> createtByUser = new List<Route>();

            using (var rctx = new RoutesContext())
            {
                var query = rctx.Routes.Where(r => r.createdBy == userManager.GetUserName(User));

                foreach (Route route in query)
                {
                    route.connected = null;
                    createtByUser.Add(route);
                }
            }

            ViewData["Routes"] = createtByUser;
            ViewData["Title"] = "Vytvořené jízdy";

            if (createtByUser.Count == 0)
                TempData["EmptyErrMessage"] = "Dosud jsi nenabídl žádné jízdy";

            return View("FindRouteResolutTable");

        }

        [Authorize]
        [Route("/Route/Delete")]
        [HttpPost]
        public void DeleteRoute(int id)
        {


            using (var ctx = new RoutesContext())
            {
                Route ro = new Route();
                ro = ctx.Routes.Where(r => r.id == id).FirstOrDefault();

                if (ro.createdBy.Equals(userManager.GetUserName(User)))
                {

                    var routesToDelete = ctx.routeUsers.Where(r => r.RoutId == id);
                    foreach (RouteUser ru in routesToDelete)
                    {
                        ctx.Remove(ru);
                    }


                    ro = ctx.Routes.Where(r => r.id == id && r.createdBy == userManager.GetUserName(User)).FirstOrDefault();
                    ctx.Routes.Remove(ro );
                    ctx.SaveChanges();
                }
            }


        }


    }
}