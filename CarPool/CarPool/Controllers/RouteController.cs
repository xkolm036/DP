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
using Microsoft.Extensions.DependencyInjection;

namespace CarPool.Controllers
{
    public class RouteController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ApplicationDbContext _db;

        public RouteController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._db = db;
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





            var query = from ro in _db.routes
                        where route.startDestination == ro.startDestination && route.finalDestination == ro.finalDestination && ro.CreatedBy.Id != userManager.GetUserId(User)
                        select ro;

            //Select route is 1h horizont
            foreach (Route routeFromQuery in query)
            {
                if (route.date.AddMinutes(-30).Ticks <= routeFromQuery.date.Ticks && routeFromQuery.date.Ticks <= route.date.AddMinutes(30).Ticks)
                    routes.Add(routeFromQuery);
            }

            //Mark allready joined routes
            var selectedroutes = _db.routeUsers.Where(ru => ru.UserId == userManager.GetUserId(User));
            foreach (RouteUser selrout in selectedroutes)
            {
                selrout.Route.connected = true;
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
            route.date = route.date.Add(route.time.TimeOfDay);
            route.CreatedBy = _db.Users.Where(u => u.Id == userManager.GetUserId(User)).FirstOrDefault();
            _db.routes.Add(route);
            _db.SaveChanges();

            return View("AddRouteNextStep");
        }


        [Route("/Create")]
        [Authorize]
        public IActionResult CreateRouteForm()
        {

            ViewData["UsersCars"] = _db.cars.Where(c => c.AppUser.Id == userManager.GetUserId(User)).ToList();
            ViewData["Message"] = "Your application description page.";

            if ((ViewData["UsersCars"] as List<Car>).Count == 0)
            {
                TempData["msg-error"] = "Nejprve si musite v sekci moje vozidla pridat automobil";
            }

            return View();
        }


        [Route("/Route/ShowDetail")]
        public IActionResult ShowDetail(int id)
        {
            ViewData["Message"] = "Your application description page.";
            Route routeFromDb = new Route();
            routeFromDb = _db.routes.Where(r => r.id == id).FirstOrDefault();
            return View(routeFromDb);
        }

        [Authorize]
        [HttpPost]
        [Route("/Route/JoinRoute")]
        public void JoinRoute(int id)
        {
            _db.routeUsers.Add(new RouteUser { RouteId = id, UserId = userManager.GetUserId(User) });
            _db.SaveChanges();
        }

        [Authorize]
        [HttpPost]
        [Route("/Route/LeaveRoute")]
        public void LeaveRoute(int id)
        {
            ViewData["Message"] = "Your application description page.";
            Route routeFromDb = new Route();

                var routeTodelete = _db.routeUsers.Where(ru => ru.RouteId == id && ru.UserId == userManager.GetUserId(User)).FirstOrDefault();
                _db.routeUsers.Remove(routeTodelete);
                _db.SaveChanges();
        }

        [Authorize]
        [Route("/Route/Logged")]
        public IActionResult ShowLoggedRoutes()
        {
            List<Route> myRoutes = new List<Route>();
       

       
                var query = from RouteUser in _db.routeUsers
                            join route in _db.routes on RouteUser.RouteId equals route.id
                            where RouteUser.UserId == userManager.GetUserId(User) && route.id == RouteUser.RouteId
                            select route;


                foreach (Route routeFromQuery in query)
                {
                    routeFromQuery.connected = true;
                    myRoutes.Add(routeFromQuery);
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

       
                var query = _db.routes.Where(r => r.CreatedBy.Id == userManager.GetUserId(User));

                foreach (Route route in query)
                {
                    route.connected = null;
                    createtByUser.Add(route);
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


                Route ro = new Route();
                ro = _db.routes.Where(r => r.id == id).FirstOrDefault();

                if (ro.CreatedBy.Id.Equals(userManager.GetUserId(User)))
                {

                    var routesToDelete = _db.routeUsers.Where(r => r.RouteId == id);
                    foreach (RouteUser ru in routesToDelete)
                    {
                        _db.Remove(ru);
                    }


                    ro = _db.routes.Where(r => r.id == id && r.CreatedBy.Id == userManager.GetUserId(User)).FirstOrDefault();
                    _db.routes.Remove(ro);
                    _db.SaveChanges();
                }
          


        }


    }
}