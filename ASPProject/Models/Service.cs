using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public DateTime LastPickup { get; set; }


        public DateTime NextPickup { get; set; }

        [Required]
        public string PickupDay { get; set; }

        public decimal Balance { get; set; }

        
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public ApplicationUser AspNetUsers { get; set; }
    }
}