using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPool.Models
{
    public class RouteUser
    {
        [Key]
        public  int id { get; set; }
        
        public string UserId { get; set; }
       // public AppUser user { get; set; }

  
        public int RoutId { get; set; }
      //  public Route Route { get; set; }


    }
}
