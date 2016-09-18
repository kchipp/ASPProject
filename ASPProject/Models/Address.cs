﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public bool Type { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }
        public double Latitude { get; set; }
        public double  Longitude { get; set; }



        [ForeignKey ("AspNetUsers")]
        public string UserId { get; set; }
        public ApplicationUser AspNetUsers { get; set; }
    }
}