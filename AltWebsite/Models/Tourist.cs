using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Tourist
    {
        public int Id { get; set; }
        public int TouristInfoId { get; set; }
        public string Comments { get; set; }
        public string Review { get; set; }
        public virtual TouristInfo TouristInfo { get; set; }
        public virtual List<Booking> Bookings { get; set; }

    }
}