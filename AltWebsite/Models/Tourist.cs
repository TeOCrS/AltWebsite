using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Tourist
    {
        public int Id { get; set; }

        [DisplayName("Tourist")]
        public string FirstName { get; set; }

        [DisplayName("Tourist Name")]
        public string LastName { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Pref Language")]
        public string PreferedLanguage { get; set; }

        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }

        [DisplayName("Review")]
        public string Review { get; set; }

        [DisplayName("Bookings")]
        public virtual List<Booking> Bookings { get; set; }
    }
}