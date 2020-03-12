using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarPool.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

       public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Route("/User/get")]
        public void GetUserts()
        {
            IEnumerable<AppUser> users = userManager.Users;


            int a = 10;

        }

    }
}