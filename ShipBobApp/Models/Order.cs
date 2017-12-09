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

        [StringLength(50, MinimumLength = 3)]
        public string TrackingId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string RecipientName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string StreetAddress { get; set; }
        [StringLength(25, MinimumLength = 2)]
        public string City { get; set; }
        [StringLength(25, MinimumLength = 2)]
        public string State { get; set; }
        
        public int ZipCode { get; set; }


        public int UserId { get; set; }
        public User Customer { get; set; }


    }
}
