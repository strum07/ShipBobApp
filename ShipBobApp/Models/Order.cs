using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipBobApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }


        [Required(ErrorMessage = "Required : To make sure your customers can track the order")]
        [StringLength(50, MinimumLength = 3)]
        public string TrackingId { get; set; }

        [Required(ErrorMessage = "Required : Who are we sending this to? Nice to put a name on it, innit? :)")]
        [StringLength(50, MinimumLength = 3)]
        public string RecipientName { get; set; }

        [Required(ErrorMessage = "Required : So that the postal office aren't treasure hunting :D")]
        [StringLength(50, MinimumLength = 5)]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Required : You already know why! ")]
        [StringLength(25, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string State { get; set; }
        
        public int ZipCode { get; set; }


        public int UserId { get; set; }
        public User Customer { get; set; }


    }
}
