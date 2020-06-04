using System;
using System.Collections.Generic;
using System.Linq;
using CarPool.Data;
using CarPool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ImageMagick;


namespace CarPool.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public CarsController(ApplicationDbContext db, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _db = db;
            this._userManager = userManager;
            _env = env;
        }

        public List<Car> findMyCars()
        {
            List<Car> carsFromDb = new List<Car>();
            // carsFromDb = _db.cars.Where(c=>c.AppUser.Id==_userManager.GetUserId(User)).ToList();
            carsFromDb = _db.cars.Include(x => x.AppUser).Where(c => c.AppUser.Id == _userManager.GetUserId(User)).ToList();
            return carsFromDb;

        }

        [Route("/Car/UploadImage")]
        public IActionResult UploadImage(IFormFile file, int id)
        {
           


            Car c = new Car();
            c = _db.cars.Where(c => c.AppUser.Id == _userManager.GetUserId(User) && c.id == id).FirstOrDefault();

                if (file.ContentType == "image/png" || file.ContentType == "image/jpeg")
                {
                    if (file.Length > 20971520)  //20 Mb
                    {
                        TempData["msg-error"] = "Obrazek nesmi být větší než 20 MB";
                    }
                    else
                    {

                    var filePath = Path.GetTempFileName();

                    //  string filePath = Path.Combine(_env.WebRootPath, "Temp");
                    //  string pripona = file.FileName.Split(".")[1];
                    //  string filepath = Path.Combine(filePath, "image_" + c.id.ToString() + ".jpg");


                    //   var optimizer = new ImageOptimizer();
                    //   optimizer.LosslessCompress(image);
                    //   image.CopyTo(filepath);

                    file.CopyTo(new FileStream(filePath,FileMode.Create));
                    return Content(filePath);

                }



                }
                else
                {
                    TempData["msg-error"] = "Je povolen pouze format png a jpg";
                }

            
            return Content("OK");
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
        public IActionResult AddCar(Car newCar, IFormFile file)
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
                ViewData["Cars"] = newCar;
            }

            if (file.ContentType == "image/png" || file.ContentType == "image/jpeg")
            {
                if (file.Length > 20971520)  //20 Mb
                {
                    TempData["msg-error"] = "Obrazek nesmi být větší než 20 MB";
                }
                else
                {

                   string filePath = Path.Combine(_env.WebRootPath, "images");
                   string pripona = file.FileName.Split(".")[1];
                   string filepath = Path.Combine(filePath, "image_" + newCar.id + "."+pripona);


                    //   var optimizer = new ImageOptimizer();
                    //   optimizer.LosslessCompress(image);
                    //   image.CopyTo(filepath);

                    file.CopyTo(new FileStream(filepath, FileMode.Create));

              

                }



            }
            else
            {
                TempData["msg-error"] = "Je povolen pouze format png a jpg";
            }

            return Content(newCar.id.ToString());
        }





    }
}