using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPool.Models
{
    public class AppUser:IdentityUser
    {
       public IList<RouteUser> RouteUser { get; set; }
    }
}
