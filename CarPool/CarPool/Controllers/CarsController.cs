using System;
using System.Collections.Generic;
using System.Linq;
using CarPool.Data;
using CarPool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPool.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public CarsController(ApplicationDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            this._userManager = userManager;
        }

        public List<Car> findMyCars()
        {
            List<Car> carsFromDb = new List<Car>();
            carsFromDb = _db.cars.Where(c=>c.AppUser.Id==_userManager.GetUserId(User)).ToList();
            return carsFromDb;

        }

        [Route("/Car/My")]
        public IActionResult ShowMyCars()
        {
            //    = _db.cars.in
            ViewData["Cars"] = this.findMyCars();
            return View("ShowMyCars");
        }


        [Route("/Car/AddEmpty")]
        public IActionResult AddEmptyCar()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car());
            ViewData["Cars"] = cars;
            return PartialView("_PartialGenerateCards");
        }

        [Route("/Car/GetSeats")]
        public IActionResult GetCarSeats(int id)
        {
            Car carFromDb = new Car();
            carFromDb = _db.cars.Where(c => c.id == id && c.AppUser.Id==_userManager.GetUserId(User)).FirstOrDefault();
            if (carFromDb == null)
            {
                ViewBag.seats = 0;
            }
            else
            {
                ViewBag.seats = carFromDb.seats;
            }

            return PartialView("_seatsSelect");
        }


        [Route("/Car/Delete")]
        public void DeleteCar(int id)
        {

            Car carFromDb = _db.cars.Where(c => c.id == id && c.AppUser.Id == _userManager.GetUserId(User)).FirstOrDefault();
            if (carFromDb != null)
            {
                _db.cars.Remove(carFromDb);
                _db.SaveChanges();

            }

        }


        [Route("/Car/Add")]
        [HttpPost]
        public IActionResult AddCar(Car newCar)
        {
            //try to find in db
            Car carFromDb = new Car();
            carFromDb = _db.cars.Where(c => c.id == newCar.id && c.AppUser.Id==_userManager.GetUserId(User)).FirstOrDefault();


            //modify existing car
            if (carFromDb != null)
            {
                carFromDb.brand = newCar.brand;
                carFromDb.color = newCar.color;
                carFromDb.description = newCar.description;
                carFromDb.image = newCar.image;
                carFromDb.model = newCar.model;
                carFromDb.seats = newCar.seats;
                carFromDb.spz = newCar.spz;
                _db.SaveChanges();
            }
            else //new car
            {
                newCar.AppUser = _db.Users.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();
                _db.cars.Add(newCar);
                _db.SaveChanges();

            }

            return PartialView("_PartialGenerateCards");
        }





    }
}