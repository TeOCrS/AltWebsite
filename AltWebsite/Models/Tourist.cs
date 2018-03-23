using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Tourist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string PreferedLanguage { get; set; }
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
        public string Review { get; set; }
        public virtual List<Booking> Bookings { get; set; }

    }
}