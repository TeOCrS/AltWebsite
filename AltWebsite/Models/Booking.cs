using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int TouristId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Interval { get; set; }
        public ComingFromWebsite Website { get; set; }


        public virtual Payment Payment { get; set; }
    }
}