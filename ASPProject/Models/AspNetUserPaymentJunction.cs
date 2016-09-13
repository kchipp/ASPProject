using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class AspNetUserPaymentJunction
    {
        [Key]
        public int UserPaymentId { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public ApplicationUser AspNetUsers { get; set; }

        [ForeignKey ("Payments")]
        public int PaymentId { get; set; }
        public Payment Payments { get; set; }

    }
}