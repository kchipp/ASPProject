using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }


        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public ApplicationUser AspNetUsers { get; set; }

        [ForeignKey("Addresses")]
        public int AddressId { get; set; }
        public Address Addresses { get; set; }

        [ForeignKey ("Services")]
        public int ServiceId { get; set; }
        public Service Services { get; set; }
    }
}