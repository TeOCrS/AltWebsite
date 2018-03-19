using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Tourist
    {
        public int Id { get; set; }
        public TouristInfo TouristInfo { get; set; }
        public List<Booking> Bookings { get; set; }
        public string Comments { get; set; }
        public string Review { get; set; }
    }
}