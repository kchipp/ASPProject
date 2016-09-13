using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class UserRouteJunction
    {
        [Key]
        public int UserRouteId { get; set; }

        [ForeignKey ("Route")]
        public int RouteId { get; set; }
        public Route Route { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public ApplicationUser AspNetUsers { get; set; }
    }
}