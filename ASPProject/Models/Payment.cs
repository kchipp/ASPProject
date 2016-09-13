using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public bool PaymentMethod { get; set; }
        [Required]
        public string CardType { get; set; }
        [Required]
        public long CardNumber { get; set; }
        [Required]
        public int ExpirationDate { get; set; }
        [Required]
        public int SecurityCode { get; set; }

    }
}