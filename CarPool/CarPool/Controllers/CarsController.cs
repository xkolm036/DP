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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        private bool isCarValid(Car c)
        {
            bool validationState = true;
            var nameRegex = new Regex(@"^[a-zA-Zá-žÁ-Ž]*$", RegexOptions.Compiled);
            var czAlfabetWithNumer = new Regex(@"^[a-zA-Zá-žÁ-Ž0-9\s]*$", RegexOptions.Compiled);
            var spzRegex = new Regex(@"^[A-Za-z0-9]{3}[\s-][0-9]{4}$", RegexOptions.Compiled);
            var descriptionRegex = new Regex(@"^[a-zA-Zá-žÁ-Ž ?!.()[\]{}]*$", RegexOptions.Compiled);


            if (c.brand != null)
            {
                if (!nameRegex.IsMatch(c.brand.Trim()))
                {
                    TempData["brand-error"] = "Špatně zadaný výrobce";
                    validationState = false;
                }
            }
            else
            {
                TempData["brand-error"] = "Vyýrobce není vyplněn";
            }

            if (c.color != null)
            {
                if (!nameRegex.IsMatch(c.color.Trim()))
                {
                    TempData["color-error"] = "Špatně zadaná barva";
                    validationState = false;
                }
            }
            else
            {
                TempData["color-error"] = "Není vyplněna barva";
            }

            if (c.model != null)
            {
                if (!czAlfabetWithNumer.IsMatch(c.model.Trim()))
                {
                    TempData["model-error"] = "Špatně vyplněn model auta";
                    validationState = false;
                }
            }
            else
            {
                TempData["model-error"] = "Není vyplněn model auta";
            }

            if (c.description != null)
            {
                if (!descriptionRegex.IsMatch(c.description))
                {
                    TempData["description-error"] = "Popis nesmí obsahovat speciální znaky";
                }
            }

            if (c.seats <= 0)
            {
                TempData["seats-error"] = "Špatně vyplněn počet míst";
            }

            if (c.spz != null)
            {
                if (!spzRegex.IsMatch(c.spz))
                {
                    TempData["spz-error"] = "SPZ je ve špatném formátu";
                }
            }


            return validationState;

        }

        private void compressImage(string path)
        {
            var file = new FileInfo(path);

            Console.WriteLine("Bytes before: " + file.Length);

            var optimizer = new ImageOptimizer();
            optimizer.Compress(file);

            file.Refresh();
            Console.WriteLine("Bytes after:  " + file.Length);

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

                    file.CopyTo(new FileStream(filePath, FileMode.Create));
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
            carFromDb = _db.cars.Where(c => c.id == id && c.AppUser.Id == _userManager.GetUserId(User)).FirstOrDefault();
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
            List<Car> cars = new List<Car>();

            //validate inputs and set error messages
            if (!isCarValid(newCar))
            {
                cars.Add(newCar);
                ViewData["Cars"] = cars;
                return PartialView("_PartialGenerateCards");
            }


            //try to find in db
            Car carFromDb = new Car();
            carFromDb = _db.cars.Where(c => c.id == newCar.id && c.AppUser.Id == _userManager.GetUserId(User)).FirstOrDefault();

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
                carFromDb.AppUser = _db.Users.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();

                cars.Add(carFromDb);
            }
            else //new car
            {
                  newCar.AppUser = _db.Users.Where(u => u.Id == _userManager.GetUserId(User)).FirstOrDefault();
                  newCar.id = 0; //prevet to edit car of enother user
                  _db.cars.Add(newCar);
                  _db.SaveChanges();
                  cars.Add(newCar);
            }

            if (file != null)
            {
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
                        string filepath = Path.Combine(filePath, "image_" + newCar.id + "." + pripona);

                        using (var stream = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(stream);
                        }
                       // file.CopyTo(new FileStream(filepath, FileMode.Create));

                        Task.Run(()=>compressImage(filepath));
                    }

                }
                else
                {
                    TempData["msg-error"] = "Je povolen pouze format png a jpg";
                }
            }

            // return Content(newCar.id.ToString());

            ViewData["cars"] = cars;
            return PartialView("_PartialGenerateCards");
        }





    }
}